using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TestSpire
{
    public partial class Modificar : MaterialForm
    {
        private Functions ft = new Functions();
        private SqlDataReader reader;
        private string Folio;
        private int Usrid;

        public Modificar(string folio, int usrid)
        {
            Folio = folio;
            InitializeComponent();
            reader = ft.GetAllCC(folio);
            Usrid = usrid;
            documentador.Text = "Documentador: " + reader.GetValue(reader.GetOrdinal("Documentador")).ToString();
            folioLabel.Text = reader.GetValue(reader.GetOrdinal("Folio")).ToString();
            documento.Text = reader.GetValue(reader.GetOrdinal("Documento")).ToString();
            FechaDeEmision.Text = reader.GetValue(reader.GetOrdinal("FechaDeEmision")).ToString();
            FechaDeRegistro.Text = reader.GetValue(reader.GetOrdinal("FechaRegistro")).ToString();
            NoHojas.Text = reader.GetValue(reader.GetOrdinal("Hojas")).ToString();
            uso.Text = reader.GetValue(reader.GetOrdinal("Uso")).ToString();
            frs.Text = reader.GetValue(reader.GetOrdinal("FRS")).ToString();
        }

        private void Modificar_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet3.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.browserDataSet3.Clientes);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet3.Tipo_Servicio' Puede moverla o quitarla según sea necesario.
            this.tipo_ServicioTableAdapter.Fill(this.browserDataSet3.Tipo_Servicio);

            TipoServicio.SelectedIndex = TipoServicio.FindString(reader.GetValue(reader.GetOrdinal("TipoServicio")).ToString());
            cliente.SelectedIndex = cliente.FindString(reader.GetValue(reader.GetOrdinal("Cliente")).ToString());

            estatus.SelectedIndex = estatus.FindString(reader.GetValue(reader.GetOrdinal("Estatus")).ToString());
        }

        private void save_Click(object sender, EventArgs e)
        {
            string sql = "";
            DateTime dd, dd1;
            if (estatus.SelectedItem.ToString() == "Activo"
                && DateTime.TryParse(FechaDeEmision.Text, out dd)
                && DateTime.TryParse(FechaDeRegistro.Text, out dd1)

                )
            {
                sql = "update CopiasControladas set FechaEmision='" + ft.Date2(dd) + "'," +
                    "FechaRegistro='" + ft.Date2(dd1) + "'," +
                    "Uso='" + uso.Text + "'," +
                    "IdTipoServicio='" + TipoServicio.SelectedValue + "'," +
                    "IdCliente='" + cliente.SelectedValue + "'," +
                    "IdFrs='" + frs.Text + "'," +
                    "Estatus=1" +
                   "Where Folio=" + Folio + ";"
                    ;
            }
            else if (estatus.SelectedItem.ToString() == "Cancelada"
                && DateTime.TryParse(FechaDeEmision.Text, out dd)
                && DateTime.TryParse(FechaDeRegistro.Text, out dd1))
            {
                sql = "update CopiasControladas set FechaEmision='" + ft.Date2(dd) + "'," +
                   "FechaRegistro='" + ft.Date2(dd1) + "'," +
                   "Uso='" + uso.Text + "'," +
                   "IdTipoServicio='" + TipoServicio.SelectedValue + "'," +
                   "IdCliente='" + cliente.SelectedValue + "'," +
                   "IdFrs='" + frs.Text + "'," +
                   "Estatus=0" +
                   " Where Folio=" + Folio + ";"
                   ;
            }

            /*Creación de objetos JSON que se guardan en la tabla LogCC(Log de cambios en Copias controladas)
             * Los objetos almacenan el estado previo al cambio y los cambios efectuados
             * al registro. Cada cambio genera una tupla en la tabla
             */
            var cc_old = new CC//Objeto Json con datos anteriores
            {
                Folio = reader.GetValue(reader.GetOrdinal("Folio")).ToString(),
                Documento = reader.GetValue(reader.GetOrdinal("Documento")).ToString(),
                FechaDeEmision = ft.ToDate(reader.GetValue(reader.GetOrdinal("FechaDeEmision")).ToString()),
                FechaDeRegistro = ft.ToDate(reader.GetValue(reader.GetOrdinal("FechaRegistro")).ToString()),
                Hojas = reader.GetValue(reader.GetOrdinal("Hojas")).ToString(),
                Uso = reader.GetValue(reader.GetOrdinal("Uso")).ToString(),
                TipoServicio = reader.GetValue(reader.GetOrdinal("TipoServicio")).ToString(),
                Cliente = reader.GetValue(reader.GetOrdinal("Cliente")).ToString(),
                FRS = reader.GetValue(reader.GetOrdinal("FRS")).ToString(),
                Documentador = reader.GetValue(reader.GetOrdinal("Documentador")).ToString(),
                Estatus = reader.GetValue(reader.GetOrdinal("Estatus")).ToString()
            };
            var cc_new = new CC//Objeto Json con datos nuevos(campos modificables)
            {
                Folio = reader.GetValue(reader.GetOrdinal("Folio")).ToString(),
                Documento = reader.GetValue(reader.GetOrdinal("Documento")).ToString(),
                FechaDeEmision = ft.ToDate(FechaDeEmision.Text),
                FechaDeRegistro = ft.ToDate(FechaDeRegistro.Text),
                Hojas = reader.GetValue(reader.GetOrdinal("Hojas")).ToString(),
                Uso = uso.Text,
                TipoServicio = TipoServicio.SelectedItem.ToString(),
                Cliente = TipoServicio.SelectedItem.ToString(),
                FRS = reader.GetValue(reader.GetOrdinal("FRS")).ToString(),
                Documentador = reader.GetValue(reader.GetOrdinal("Documentador")).ToString(),
                Estatus = estatus.SelectedItem.ToString()
            };
            /*Cadenas json serializadas*/
            string jsonCcOld = JsonSerializer.Serialize(cc_old);
            string jsonCcNew = JsonSerializer.Serialize(cc_new);
            string Log = "Insert into LogCC(Folio,Previo,Nuevo,IdUsuario,FechaCambio,Cambio) " +

                         " values(" + Folio + ", '" + jsonCcOld + "', '" + jsonCcNew + "', " + Usrid + ", '" + ft.Date2(DateTime.Now) + "', 'Update'); ";
            if (ft.SetSql(sql) && ft.SetSql(Log))
            {
                MessageBox.Show("Registro Modificado");
                this.Close();
            }
            else
            {
                MessageBox.Show("Algo Salio Mal.");
                this.Close();
            }
        }
    }

    public class CC //Clase modelo para Objetos con información de copias controladas
    {
        public string Folio { get; set; }

        public string Documento { get; set; }
        public DateTime FechaDeEmision { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public string Hojas { get; set; }
        public string Uso { get; set; }
        public string TipoServicio { get; set; }
        public string Cliente { get; set; }
        public string FRS { get; set; }
        public string Documentador { get; set; }
        public string Estatus { get; set; }
    }
}