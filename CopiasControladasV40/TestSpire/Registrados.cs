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
using TestSpire.ConsultaTablaTableAdapters;

namespace TestSpire
{
    public partial class Registrados : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;

        Functions fn = new Functions();

        //******************* DESACTIVA EL BOTON DE CERRAR EN EL FORM
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //}


        //**************** EVITA PARPADEO EN GRID
        public new static void DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }


        //****************** CARGA LOS DATOS EN EL GRID 
        public Registrados()
        {
            InitializeComponent();
            DataTable1TableAdapter rg = new DataTable1TableAdapter();
            dataGridView1.DataSource = rg.GetData();
            Timer timer = new Timer();
            timer.Interval = (3 * 1000); // 1 secs
            timer.Tick += new EventHandler(Timer1_Tick);
            timer.Start();
            DoubleBuffered(dataGridView1, true);
        }


        //***************** EJECUTA LA ACTUALIZACION CADA SEGUNDO
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            FillDataGridView();
        }


        //************************ ACTUALIZA LA VISTA DE LOS REGISTROS
        protected void FillDataGridView()
        {
            
            DataTable1TableAdapter rg = new DataTable1TableAdapter();
            dataGridView1.DataSource = rg.GetData();
            dataGridView1.Refresh();
            GC.Collect();
            //dataGridView1.Rows.Clear();
        }



        private void Registrados_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet2.GetCC' Puede moverla o quitarla según sea necesario.
            //this.getCCTableAdapter.Fill(this.browserDataSet2.GetCC);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet3.CopiasControladas' Puede moverla o quitarla según sea necesario.

            dataGridView1.DataSource = fn.getRegistrosCC();

        }
    }
}
