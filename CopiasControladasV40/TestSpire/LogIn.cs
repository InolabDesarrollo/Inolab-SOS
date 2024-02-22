using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Data.SqlClient;

namespace TestSpire
{
    public partial class LogIn : Form
    {
        private string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public LogIn()
        {
            try
            {
                /*
                 * Inicialización de Autoupdater, en el xml en la ruta de Public
                 * se puede manipular la forma en la que se deben instalar las actualizaciones
                 */
                Console.WriteLine(System.Reflection.Assembly.GetEntryAssembly().GetName().Version);
                AutoUpdater.Start(@"\\192.168.15.134\Public\Firmas\versions.xml");

                InitializeComponent();

                version.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private Functions FT = new Functions();

        private void Ingresar()
        {
            SqlDataReader Log = FT.GetRead("Select * from usuarios where Usuario='" + user.Text + "' and Password_='" + pass.Text + "'", FT.connectionDB);
            if (Log != null)
            {
                Usr.Rick = (int)Log.GetValue(Log.GetOrdinal("IdArea"));
                Usr.Joi = (int)Log.GetValue(Log.GetOrdinal("IdRol"));
                Usr.K = (int)Log.GetValue(Log.GetOrdinal("IdUsuario"));
                Usr.Nombre = (string)Log.GetValue(Log.GetOrdinal("Nombre"));
                if (Log.GetValue(Log.GetOrdinal("Firma")) is DBNull)
                {
                }
                else
                {
                    Usr.Firma = FT.byteArrayToImage((byte[])Log.GetValue(Log.GetOrdinal("Firma")));
                }
                //
                if (Usr.Rick == 3 || Usr.Rick == 5 || Usr.Rick == 4 || Usr.Rick == 7)
                {
                    this.Hide();

                    if (Usr.Joi == 4 || Usr.Joi == 5)
                    {
                        //Form que se muestra para administrar las copias controladas
                        Consultar adm = new Consultar();
                        adm.Show();
                        //string file = @"C:\Users\Public\Documents\usr.json";
                        //MessageBox.Show(file);
                        //string jsonString = JsonSerializer.Serialize(usr);
                        //File.WriteAllText(file, jsonString);
                    }
                    else
                    {
                        //Form para crear copias controladas
                        Form1 CopiasControladas = new Form1();
                        CopiasControladas.Show();
                        //Save to file

                        //string file = @"C:\Users\Public\Documents\usr.json";
                        //MessageBox.Show(file);
                        //string jsonString = JsonSerializer.Serialize(usr);
                        //File.WriteAllText(file, jsonString);
                    }
                }
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña no reconocidos");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void LogIn_Activated(object sender, EventArgs e)
        {
            try
            {
                /*
                string fileName = @"C:\Users\Public\Documents\usr.json";
                if (File.Exists(fileName))
                {
                    string jsonString = File.ReadAllText(fileName);
                    usrV = JsonSerializer.Deserialize<Usuario>(jsonString);

                    if (FT.Log(usrV.K, usrV.Joi)) {
                        if (usrV.Joi == 4 || usrV.Joi == 5)
                        {
                            Consultar adm = new Consultar(usrV.K, usrV.Rick, usrV.Joi, usrV.Nombre);
                            adm.Show();
                            this.Hide();
                        }
                        else
                        {
                            Form1 CopiasControladas = new Form1(usrV.K, usrV.Rick, usrV.Joi, usrV.Nombre);
                            CopiasControladas.Show();
                            this.Hide();
                        }
                    }
                }
                */
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 53)
                {
                    MessageBox.Show("Error De Conexion Con el Servidor.");
                }
                else
                {
                    MessageBox.Show(sqle.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Ingresar();
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}