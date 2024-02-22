using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TestSpire
{
    public partial class Admon : MaterialForm
    {
        private Image firma;
        private Functions ft = new Functions();
        private string set;

        public Image Firma { get => firma; set => firma = value; }
        public string Set { get => set; set => set = value; }
        private static string PathR = AppContext.BaseDirectory;
        private string page = PathR + @"Rubricas\Sgn\get.html";
        public string Route = @"C:\Users\Public\Documents\sgn.png";


        //********************CONVIERTE IMAGEN EN ARREGLO BYTE
        public void Open()
        {
            //CARGA LA IMAGEN DE LA FIRMA DEL USUARIO
            try
            {
                openFileDialog1.Multiselect = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string ext = Path.GetExtension(openFileDialog1.FileName);
                    string route = ft.SvgPng(openFileDialog1.FileName);
                    switch (ext)
                    {
                        case ".svg":

                            if (ft.IsValid(route))
                            {
                                pictureBox1.ImageLocation = route;
                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                Firma = Image.FromFile(route);
                            }
                            break;

                        case ".png":
                            pictureBox1.ImageLocation = route;
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            Firma = Image.FromFile(route);

                            break;

                        default:
                            MessageBox.Show("Archivo no valido");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private Timer timer = new Timer();
        private string downloadsPath = KnownFolders.Downloads.Path + @"\signature.svg";

        protected virtual bool IsFileLocked(FileInfo file)
        {
            //Verifica que el archivo de firma no esté siendo utilizado
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //El Archivo puede estar en uso
                return true;
            }

            //Archivo Libre
            return false;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            var fi1 = new FileInfo(downloadsPath);
            if (File.Exists(downloadsPath) && !IsFileLocked(fi1))
            {
                string route = ft.SvgPng(downloadsPath);
                if (route != null)
                {
                    pictureBox1.ImageLocation = route;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Firma = Image.FromFile(route);
                    timer.Dispose();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(downloadsPath))
            {
                File.Delete(downloadsPath);
            }
            //Proceso para abrir la pagina para captura de firma
            ProcessStartInfo sInfo = new ProcessStartInfo(page);
            Process.Start(sInfo);

            //timer.Interval = (3 * 1000); // 1 secs
            //timer.Tick += new EventHandler(Timer1_Tick);
            //timer.Start();
            /*Preview pv = new Preview();
            pv.Route = page;
            pv.Show();*/

            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                /*Linq query para obtener e valor de los elementos seleccionados
                 en los combobox de Area y Rol*/
                var area = from ida in Areas
                           where ida[1].Contains(comboBox2.Text)
                           select ida;
                var rol = from idr in Permisos
                          where idr[1].Contains(comboBox3.Text)
                          select idr;
                if (button2.Text == "Guardar")
                {
                    //Rutina para guardar un nuevo usuario
                    SqlConnection conn = new SqlConnection(ft.connectionDB);

                    using (var command = new SqlCommand("Insert into Usuarios(Nombre,Apellidos,Usuario,Password_,IdArea,Activo,IdRol,Firma)" +
                        "values(@nombre,@apellido,@usuario,@pass,@ida,1,@idr,@firma) ", conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("nombre", textBox1.Text);
                        command.Parameters.AddWithValue("apellido", textBox2.Text);
                        command.Parameters.AddWithValue("usuario", textBox3.Text);
                        command.Parameters.AddWithValue("pass", textBox4.Text);
                        command.Parameters.AddWithValue("ida", area.First()[0]);
                        command.Parameters.AddWithValue("idr", rol.First()[0]);

                        command.Parameters.AddWithValue("firma", ft.imageToByteArray(Firma));
                        var r = command.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Guardado");
                            Firma = null;
                            pictureBox1.Image.Dispose();
                            pictureBox1.Image = null;
                            pictureBox1.Refresh();
                        }
                        conn.Close();
                    }
                }
                else
                {
                    //Rutina para actualizar el usuario seleccionado
                    SqlConnection conn = new SqlConnection(ft.connectionDB);

                    using (var command = new SqlCommand("update Usuarios set Firma=@frm," +
                        "Nombre=@nom,Apellidos=@app,Usuario=@usr,Password_=@pss,IdArea=@ida,IdRol=@idr" +
                        " WHERE IdUsuario=@someID", conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("someID", comboBox1.SelectedValue);
                        command.Parameters.AddWithValue("frm", ft.imageToByteArray(Firma));
                        command.Parameters.AddWithValue("app", textBox2.Text);
                        command.Parameters.AddWithValue("usr", textBox3.Text);
                        command.Parameters.AddWithValue("pss", textBox4.Text);
                        command.Parameters.AddWithValue("ida", area.First()[0]);
                        command.Parameters.AddWithValue("idr", rol.First()[0]);
                        command.Parameters.AddWithValue("nom", textBox1.Text);
                        var r = command.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Guardado");
                            if ((int)comboBox1.SelectedValue == Usr.K)
                            {
                                Usr.Firma = Firma;
                            }

                            Firma = null;
                            pictureBox1.Image.Dispose();
                            pictureBox1.Image = null;
                            pictureBox1.Refresh();
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private bool populate(List<string[]> vs, ComboBox cbx)
        {
            /*BindingSource bs = new BindingSource();
            bs.DataSource = vs;
            cbx.DataSource = bs;*/
            foreach (string[] element in vs)
            {
                cbx.Items.Add(element[1]);
            }
            return true;
        }

        private List<string[]> Areas = new List<string[]> {
             new string[]{"3","Documentacion" },
             new string[]{"4","Servicio" },
             new string[]{"5","Sistemas" },
             new string[]{"6","Ingeniero" },
             new string[]{"7","Laboratorio" },
             new string[]{"1","Admon" },
             new string[]{"2","Ventas" },
        };

        private List<string[]> Permisos = new List<string[]> {
             new string[]{"2","Basico" },
             new string[]{"1","Intermedio" },
             new string[]{"4","Avanzado" },
             new string[]{"5","Administrador" },
        };

        private SqlDataReader DataU;

        private void Admon_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet2.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter1.Fill(this.browserDataSet2.Usuarios);
            populate(Areas, comboBox2);
            populate(Permisos, comboBox3);

            switch (set)
            {
                case "Nuevo":
                    label6.Visible = false;
                    comboBox1.Visible = false;

                    break;

                case "update":
                    button2.Text = "Actualizar";
                    // TODO: This line of code loads data into the 'usrs.Usuarios1' table. You can move, or remove it, as needed.
                    this.usuarios1TableAdapter.Fill(this.usrs.Usuarios1);
                    // TODO: This line of code loads data into the 'usrs.Usuarios' table. You can move, or remove it, as needed.
                    this.usuariosTableAdapter.Fill(this.usrs.Usuarios);
                    break;

                default:
                    Close();
                    break;
            }
        }

        private void Admon_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public Admon()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    /*Rutina para obtener los datos del usuario y desplegarlos en los campos correspondientes*/
                    DataU = ft.GetRead("Select * from Usuarios where idusuario=" +
                        comboBox1.SelectedValue + " and Usuario is not null", ft.connectionDB);
                    if (DataU != null)
                    {
                        textBox1.Text = DataU.GetValue(DataU.GetOrdinal("Nombre")).ToString();
                        textBox2.Text = DataU.GetValue(DataU.GetOrdinal("Apellidos")).ToString();
                        textBox3.Text = DataU.GetValue(DataU.GetOrdinal("Usuario")).ToString();
                        textBox4.Text = DataU.GetValue(DataU.GetOrdinal("Password_")).ToString();
                        string idA = DataU.GetValue(DataU.GetOrdinal("IdArea")).ToString();
                        string idR = DataU.GetValue(DataU.GetOrdinal("IdRol")).ToString();
                        var area = from ida in Areas
                                   where ida[0].Contains(idA)
                                   select ida;
                        var rol = from idr in Permisos
                                  where idr[0].Contains(idR)
                                  select idr;
                        comboBox2.SelectedIndex = comboBox2.FindStringExact(area.First()[1]);
                        comboBox3.SelectedIndex = comboBox3.FindStringExact(rol.First()[1]);
                        //MemoryStream mem = new MemoryStream((byte[])read.GetValue(0));
                        //pictureBox1.Image = Image.FromStream(mem);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        //Usr.Firma = Image.FromStream(mem);

                        //Usr.Firma = ft.byteArrayToImage((byte[])read.GetValue(0));
                        //var bitmap = Bitmap.FromStream(mem);

                        //pictureBox1.Image = Usr.Firma;
                        if (!(DataU.GetValue(DataU.GetOrdinal("Firma")) is DBNull))
                        {
                            pictureBox1.Image = ft.byteArrayToImage((byte[])DataU.GetValue(DataU.GetOrdinal("Firma")));
                            Firma = pictureBox1.Image;
                        }

                        //bitmap.Save("Sign.png");
                        //pictureBox1.Image = bitmap;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (set == "Nuevo")
            {
                textBox3.Text = ft.DeleteWS(textBox1.Text.Substring(0, 1) + textBox2.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (set == "Nuevo")
            {
                var rand = new Random();
                var bytes = new byte[1];
                rand.NextBytes(bytes);
                textBox4.Text = "Inolab." + bytes[0];
            }
        }

        private void Admon_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Admon_Deactivate(object sender, EventArgs e)
        {
            try
            {
                var fi1 = new FileInfo(downloadsPath);
                if (!IsFileLocked(fi1))
                {
                }
                else
                {
                    File.Delete(Route);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}