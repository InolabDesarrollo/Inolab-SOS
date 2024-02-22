using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TestSpire
{
    public partial class ViewCount : MaterialForm
    {
        private Functions ft = new Functions();

        private string gettotal(string id, DateTime d1, DateTime d2)
        {
            string tot = "";
            string sql = "" +
                "declare @id as int= " + id + ";" +
                 "declare @f1 as datetime = '" + d1.ToString("yyyy-MM-dd") + "';" +
                            "declare @f2 as datetime = '" + d2.ToString("yyyy-MM-dd") + "';" +

                            "declare @nom as varchar(50);" +
                            "declare @tot as int;" +
                            "WITH tbl(SalesPersonID, SalesYear, idu) " +
                "AS " +

                "(select distinct(IdFRS) as FSR, format(FechaRegistro, 'yyyy-MM-dd') as 'Fecha de registro',IdUsuario " +
                     "from CopiasControladas where IdUsuario = @id and FechaRegistro  between @f1 and @f2 " +

                    "Group By IdFRS,FechaRegistro,IdUsuario " +
                    "Having Count(*) = 1 ) " +
                " select count(*) from tbl; ";
            SqlConnection conn = new SqlConnection(ft.connectionDB);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                tot = reader.GetValue(0).ToString();
            }

            return tot;
        }

        private void test(Form form, DateTime date1, DateTime date2)
        {
            /*Consulta para obtener la cantidad de copias controladas
             * generadas por cada usuario
             * [dbo].[GetTot] es una funcion que regresa la cantidad de Folios registrados,
             * se encuentra en la BD Browser
             */
            string sql = "declare @f1 as datetime='" + date1.ToString("yyyy-MM-dd") + "';" +
                            "declare @f2 as datetime = '" + date2.AddDays(1).ToString("yyyy-MM-dd") + "';" +
                                        "select IdUsuario as 'Id de usuario',Nombre,Apellidos,[dbo].[GetTot] (u.IdUsuario, @f1, @f2) as 'FRS´s' From Usuarios as u where(idarea= 3 or idarea = 4 or idarea=5)and activo = 1" +//" and(IdRol!=3 and idrol!=5)" +
                                        "and IdUsuario not in (79, 41, 17, 26, 2, 74, 110, 45) " +
                            "order by Nombre asc;";
            ft.setDGV(sql, dataGridView2);
        }

        public new static void DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        public ViewCount()
        {
            InitializeComponent();
            DoubleBuffered(dataGridView2, true);
        }

        private void date1_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                test(this, date1.Value, date2.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ft.alert("Usuario " + dataGridView2[1, e.RowIndex].Value.ToString() + " seleccionado", "");
            RepPorUsuario rpu = new RepPorUsuario("selected", dataGridView2[0, e.RowIndex].Value.ToString(), date1.Value, date2.Value);
            rpu.ShowDialog(this);
        }

        private void ViewCount_Load(object sender, EventArgs e)
        {
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                test(this, date1.Value, date2.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }
    }
}