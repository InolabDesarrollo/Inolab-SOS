using Svg;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSpire
{
    public class Functions
    {
        //public string connectionDB = "Data Source=INOLABSERVER02;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17";
        //public string connectionDB = "Data Source=INOLABSERVER01;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17";
        public string connectionDB = "Data Source=INOLABSERVER03; Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17";


        public string Conexion;
        public string strSQL;
        SqlConnection Conn;
        SqlCommand Cmd;

        public int setDGV(string sql, DataGridView dgv)
        {
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataSet ds = new DataSet();
            da.Fill(ds, "Docs");
            dgv.DataSource = ds.Tables["Docs"];
            return 0;
        }

        public int setCBX(ComboBox cbx, string sql, string display, string value)
        {
            /*
             * Funcion para llenar un combobox con datos de un query
             * Display es la columna para mostrar
             * value es el la columna que se asignará como valor
             */
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataSet ds = new DataSet();
            da.Fill(ds, "Docs");
            cbx.DataSource = ds.Tables["Docs"];
            cbx.DisplayMember = display;
            cbx.ValueMember = value;
            return 0;
        }

        public string Date2(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }


        public DataTable getRegistrosCC()
        {
            string sql = " SELECT  Folio,Documento,FechaDeEmision=FechaEmision,FechaRegistro,Hojas=NoHojas, Uso,TipoServicio = Tipo_Servicio.Descripcion, " +
                        "Cliente = Clientes.Empresa,FRS = IdFRS, Documentador = Usuarios.Nombre + ' ' + Usuarios.Apellidos, " +
                        "case " +
                        "when Estatus = 1 then 'Activo' " +
                        "when Estatus = 0 then 'Cancelada' " +
                        "end as Estatus " +
                        "FROM CopiasControladas " +
                        "left join Tipo_Servicio on Tipo_Servicio.ID = CopiasControladas.IdTipoServicio " +
                        "left join Clientes on Clientes.IdCliente = CopiasControladas.IdCliente " +
                        "left join Usuarios on Usuarios.IdUsuario = CopiasControladas.IdUsuario";

            Conn = new SqlConnection(connectionDB);
            Conn.Open();

            Cmd = Conn.CreateCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = sql;
            Cmd.CommandTimeout = 2000;
            Cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            da.Fill(dt);
            //dgvDatos.DataSource = dt;
            try
            {
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar datos: " + ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
                Cmd.Dispose();

                strSQL = null;
                Conn = null;
                Cmd = null;
            }

        }

        public int GetLatestIDCopia()
        {
            string sql = "select top 1  * from CopiasControladas order by FechaRegistro desc ";
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int re;
            if (reader.Read())
            {
                return re = Int32.Parse(reader.GetValue(0).ToString());
            }
            else
            {
                return 0;
            }
        }

        public int SetCopia(string number, string documento, string fechaEmision, DateTime fechaRegistro, string noHojas, string uso, string idTipoServicio, string idCliente, string idFsr, string IdU)
        {
            //Generación del query de inserción de datos
            //y Obtención del Folio generado de copia controlada
            string sql = "BEGIN TRANSACTION INSERT INTO CopiasControladas(Folio,Documento,FechaEmision,FechaRegistro,NoHojas,Uso," +
                "IdTipoServicio,IdCliente,IdFRS,IdUsuario,Estatus) OUTPUT INSERTED.Folio    " +
               "select top 1 Folio=Folio+1,'" + documento + "','" +
                fechaEmision + "','" + Date2(fechaRegistro) + "','" + noHojas + "','" +
                uso + "','" + idTipoServicio + "','" + idCliente + "','" + idFsr + "','" + IdU + "','1' from CopiasControladas order by Folio desc  COMMIT TRANSACTION";
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int re;
            if (reader.Read())
            {
                return re = Int32.Parse(reader.GetValue(0).ToString());
            }
            else
            {
                return 0;
            }
        }

        public int SetCopia(string documento, string fechaEmision, DateTime fechaRegistro, string noHojas, string uso, string idTipoServicio, string idCliente, string idFsr, string IdU)
        {
            string sql =
                "INSERT INTO CopiasControladas(Documento,FechaEmision,FechaRegistro,NoHojas,Uso," +
                "IdTipoServicio,IdCliente,IdFRS,IdUsuario,Estatus)" +
                " Values('" + documento + "','" +
                fechaEmision + "','" + Date2(fechaRegistro) + "','" + noHojas + "','" +
                uso + "','" + idTipoServicio + "','" + idCliente + "','" + idFsr + "','" + IdU + "','1')";

            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            int temp = Convert.ToInt32(cmd.ExecuteNonQuery().ToString());
            conn.Close();
            int ID = GetLatestIDCopia();
            if (temp == 1)
            {
                return ID;
            }
            else
            {
                return 0;
            }
        }

        public bool Log(string user, string pass)
        {
            string sql =
              "SELECT * FROM Usuarios Where Usuario='" + user + "' and Password_='" + pass + "' and Activo='1'";
            //MessageBox.Show(sql);
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }

        public bool Log(int Id, int Rol)
        {
            string sql =
              "SELECT * FROM Usuarios Where IdUsuario='" + Id.ToString() + "' and Activo='1' and IdRol=" + Rol + ";";
            //MessageBox.Show(sql);
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }

        public int getArea(string user, string pass)
        {
            string sql = "select IdArea from Usuarios where Usuario='" + user + "' and Password_='" + pass + "' ";
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int re;
            if (reader.Read())
            {
                return re = Int32.Parse(reader.GetValue(0).ToString());
            }
            else
            {
                return 0;
            }
        }

        public int getRol(string user, string pass)
        {
            string sql = "select IdRol from Usuarios where Usuario='" + user + "' and Password_='" + pass + "' ";
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int re;
            if (reader.Read())
            {
                return re = Int32.Parse(reader.GetValue(0).ToString());
            }
            else
            {
                return 0;
            }
        }

        public int getIdUsuario(string user, string pass)
        {
            string sql = "select IdUsuario from Usuarios where Usuario='" + user + "' and Password_='" + pass + "' ";
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int re;
            if (reader.Read())
            {
                return re = Int32.Parse(reader.GetValue(0).ToString());
            }
            else
            {
                return 0;
            }
        }

        public string getNombre(string user, string pass)
        {
            string sql = "select Nombre from Usuarios where Usuario='" + user + "' and Password_='" + pass + "' ";
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string re;
            if (reader.Read())
            {
                return re = reader.GetValue(0).ToString();
            }
            else
            {
                return "0";
            }
        }

        public string getNombre(string id)
        {
            string sql = "select Nombre from Usuarios where IdUsuario='" + id + "' ";
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string re;
            if (reader.Read())
            {
                return re = reader.GetValue(0).ToString();
            }
            else
            {
                return "0";
            }
        }

        public SqlDataReader GetAllCC(string folio)
        {
            string sql = "SELECT  Folio,Documento,FechaDeEmision=FechaEmision,FechaRegistro,Hojas=NoHojas," +

                        "Uso,TipoServicio = Tipo_Servicio.Descripcion,Cliente = Clientes.Empresa," +
                        "FRS = IdFRS," +
                        "Documentador=Usuarios.Nombre+' '+Usuarios.Apellidos," +
                        "case" +
                            " when Estatus = 1 then 'Activo'" +

                            " when Estatus = 0 then 'Cancelada'" +

                        " end as Estatus" +

                        " FROM CopiasControladas" +

                        " left join Tipo_Servicio on Tipo_Servicio.ID = CopiasControladas.IdTipoServicio" +

                        " left join Clientes on Clientes.IdCliente = CopiasControladas.IdCliente" +
                        " left join Usuarios on Usuarios.IdUsuario=CopiasControladas.IdUsuario" +
                        " where folio = '" + folio + "'" +

                        " order by FechaEmision DESC; ";
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                //return re = reader.GetValue(reader.GetOrdinal("")).ToString();
                return reader;
            }
            else
            {
                return null;
            }
        }

        public void alert(string message, string caption)
        {
            var w = new Form() { Size = new Size(0, 0) };
            Task.Delay(TimeSpan.FromSeconds(0.85))
                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

            MessageBox.Show(w, message, caption);
        }

        public bool SetSql(string sql)
        {
            SqlConnection conn = new SqlConnection(connectionDB);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            int temp = Convert.ToInt32(cmd.ExecuteNonQuery().ToString());
            conn.Close();
            if (temp > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DateTime ToDate(string date)
        {
            DateTime dd;
            if (DateTime.TryParse(date, out dd))
            {
                return dd;
            }
            else
            {
                return dd;
            }
        }

        public bool IsValid(string txt)
        {
            if (String.IsNullOrWhiteSpace(txt) || String.IsNullOrEmpty(txt))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool WFile(string line)
        {
            //Se puede crear un log con el folio de las copias controladas generadas
            try
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                docPath = docPath + @"\IngSigns";
                if (File.Exists(docPath))
                {
                    /*using (var sr = new StreamReader(Path.Combine(docPath, "WriteLines.txt")))
                    {
                    }*/
                    using (StreamWriter outputFile = File.AppendText(docPath))
                    {
                        outputFile.WriteLine(line);
                    }
                }
                else
                {
                    using (StreamWriter outputFile = new StreamWriter(docPath))
                    {
                        outputFile.WriteLine(line);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
                return true;
            }
        }

        public DataSet DS(string conn, string query)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);

                return dt;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString(), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

        public SqlDataReader GetRead(string query, string conection)
        {
            SqlConnection conn = new SqlConnection(conection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader;
            }
            else
            {
                return null;
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        //Byte array to photo
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public string SvgPng(string path)
        {
            string route = @"C:\Users\Public\Documents\sgn.png";
            try
            {
                if (File.Exists(route))
                {
                    //File.Delete(route);
                    //File.Create(route);
                    var byteArray = Encoding.ASCII.GetBytes(route);
                    using (var stream = new MemoryStream(byteArray))
                    {
                        var svgDocument = SvgDocument.Open(path);
                        var bitmap = svgDocument.Draw();
                        bitmap.Save(path, ImageFormat.Png);
                    }
                }
                else
                {
                    //File.Create(route);
                    var byteArray = Encoding.ASCII.GetBytes(route);
                    using (var stream1 = new MemoryStream(byteArray))
                    {
                        var svgDocument = SvgDocument.Open(path);
                        var bitmap = svgDocument.Draw();
                        bitmap.Save(route, ImageFormat.Png);
                    }
                }
                //File.Delete(route);
                return route;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public string DeleteWS(string txt)
        {
            string t = txt.Trim();
            t = t.Replace(" ", "");
            return t;
        }
    }
}