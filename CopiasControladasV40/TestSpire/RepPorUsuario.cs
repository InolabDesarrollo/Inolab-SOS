using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;


namespace TestSpire
{
    public partial class RepPorUsuario : MaterialForm
    {
        private Functions ft = new Functions();
        private string Type;

        private int cbx()
        {
            /*Funcion para llenar el datagridview
             */
            string sql;
            switch (Type)
            {
                case "frs":
                    /*Consulta para obtener datos por folio de la tabla copias controladas en Browser*/
                    sql = "declare @id as varchar(100)='" + documentador.Text + "';" +

                            "SELECT Folio, Documento, FechaEmision as 'Fecha de emision',FechaRegistro as 'Fecha de registro',Hojas = NoHojas," +
                             "       Uso,Tipo_Servicio.Descripcion as 'Tipo de servicio',Cliente = Clientes.Empresa,FRS = IdFRS," +
                              "      Documentador = Usuarios.Nombre," +
                               "     case" +
                                "        when Estatus= 1 then 'Activo'" +

                                 "       when Estatus = 0 then 'Cancelada'" +

                                  "  end as Estatus" +

                                   " FROM CopiasControladas" +

                                    " left join Tipo_Servicio on Tipo_Servicio.ID = CopiasControladas.IdTipoServicio" +

                                    " left join Clientes on Clientes.IdCliente = CopiasControladas.IdCliente" +

                                    " left join Usuarios on Usuarios.IdUsuario = CopiasControladas.IdUsuario" +

                                    " where IdFRS = @id" +

                                    " order by Folio DESC; ";
                    ft.setDGV(sql, dataGridView1);
                    break;

                default:
                    if (dateTimePicker1.Value != dateTimePicker2.Value)
                    {
                        //Consulta para obtener el numero de Folios trabajados por usuario
                        sql = "declare @id as int=" + documentador.SelectedValue + ";" +
                            "declare @f1 as datetime = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "';" +
                            "declare @f2 as datetime = '" + dateTimePicker2.Value.AddDays(1).ToString("yyyy-MM-dd") + "';" +
                            "declare @temp as table (fsr int,fr datetime,rn  int) " +
                            "insert into @temp select  distinct(IdFRS) as FSR,format(FechaRegistro, 'yyyy-MM-dd') as freg," +
                            "ROW_NUMBER() OVER(PARTITION BY idfrs ORDER BY fecharegistro DESC) AS rn  from CopiasControladas " +
                            "where IdUsuario = @id and FechaRegistro  between @f1 and @f2;" +
                            "select FSR, fr as 'Fecha de registro'" +
                            "from @temp " +
                            "where rn = 1 " +
                            "order by fr desc;";
                        ft.setDGV(sql, dataGridView1);
                    }
                    else
                    {
                        MessageBox.Show("Seleccione dos fechas distintas para continuar.");
                    }
                    break;
            }
            return 0;
        }

        public new static void DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        public RepPorUsuario(string type)
        {
            Type = type;
            try
            {
                InitializeComponent();
                DoubleBuffered(dataGridView1, true);
                string sql;
                switch (Type)
                {
                    case "usuario":
                        sql = "select * From Usuarios where (idarea=3 or idarea=4 )and activo=1 and (IdRol!=3 and idrol!=5) and firma is null order by Nombre asc";
                        ft.setCBX(documentador, sql, "Nombre", "IdUsuario");
                        break;

                    case "frs":
                        label1.Text = "FRS:";
                        label2.Visible = false;
                        label3.Visible = false;
                        dateTimePicker1.Visible = false;
                        dateTimePicker2.Visible = false;
                        sql = "select distinct(idfrs) from CopiasControladas order by idfrs desc;";
                        ft.setCBX(documentador, sql, "idfrs", "idfrs");
                        break;
                }
                documentador.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private string Nombre;
        private DateTime D1, D2;

        public RepPorUsuario(string type, string id, DateTime date1, DateTime date2)
        {
            Type = type;
            try
            {
                InitializeComponent();
                DoubleBuffered(dataGridView1, true);
                Nombre = ft.getNombre(id);
                documentador.Enabled = false;
                D1 = date1;
                D2 = date2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void dateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void documentador_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (documentador.SelectedIndex != -1)
            {
                try
                {
                    cbx();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (documentador.SelectedIndex != -1)
            {
                try
                {
                    cbx();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (documentador.SelectedIndex != -1)
            {
                try
                {
                    cbx();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }

        private void RepPorUsuario_Load(object sender, EventArgs e)
        {
            if (Type == "selected")
            {
                string sql = "select * From Usuarios where (idarea=3 or idarea=4 or idarea=5 )and activo=1  order by Nombre asc";
                //string sql = "select * From Usuarios where (idarea=3 or idarea=4 )and activo=1 and (IdRol!=3 and idrol!=5) and firma is null order by Nombre asc";
                ft.setCBX(documentador, sql, "Nombre", "IdUsuario");
                documentador.SelectedIndex = documentador.FindString(Nombre);
                dateTimePicker1.Value = D1;
                dateTimePicker2.Value = D2;
            }
        }
    }
}