using DataGridViewAutoFilter;
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
using TestSpire.ConsultaTablaTableAdapters;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TestSpire
{
    public partial class Consultar : MaterialForm
    {     


        public Consultar()
        {
            InitializeComponent();
            DoubleBuffered(ConsultaDGV, true);
        }


        //************** INSTANCIA DE CLASE FUNCIONES, PARA CONSULTAS
        private Functions ft = new Functions();

        //****INSTANCIA EL FORMULARIO
        private Admon am;


        //************ BUFFERED REDUCE PARPADEO AL CARGAR EL GRID
        public new static void DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
        

        private void ConsultaDGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        //****************** REMUEVE LOS FILTROS APLICADOS AL GRID
        private void ShowAllLabel_Click(object sender, EventArgs e)
        {
            DataGridViewAutoFilterTextBoxColumn.RemoveFilter(ConsultaDGV);
        }


        //******************* MUESTRA EL LABEL QUE QUITA LOS FILTROS AL GRID SIEMPRE Y CUANDO SE APLIQUEN FILTROS
        private void ConsultaDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            string filterStatus = DataGridViewAutoFilterColumnHeaderCell.GetFilterStatus(ConsultaDGV);
            if (string.IsNullOrEmpty(filterStatus))
            {
                ShowAllLabel.Visible = false;
                FilterStatusLabel.Visible = false;
            }
            else
            {
                ShowAllLabel.Visible = true;
                FilterStatusLabel.Visible = true;
                FilterStatusLabel.Text = filterStatus;
            }
        }


        //*************** 
        private void ConsultaDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt
            && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            && ConsultaDGV.CurrentCell != null
            && ConsultaDGV.CurrentCell.OwningColumn.HeaderCell is DataGridViewAutoFilterColumnHeaderCell filterCell)
            {
                filterCell.ShowDropDownList();
                e.Handled = true;
            }
        }


        //*************** CIERRA SESION SI NO ENCUENTRA ALGUN ARCHIVO ABIERTO O AGREGADO
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = @"C:\Users\Public\Documents\usr.json";
                if (File.Exists(fileName))
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea cerrar sesión?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Delete(fileName);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //******************** CIERRA FORMULARIO
        private void Consultar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }


        //********************** ABRE FORMULARIO PARA VISUALIZAR LOS CAMBIOS EN EL FOLIO
        private void cambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarCambios cc = new ConsultarCambios();
            cc.Show();
        }


        //*************** ABRE EL FORMULARIO CON LA INFORMACION DEL FOLIO, SE PUEDE MODIFICAR
        private void ConsultaDGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                ft.alert("Folio " + ConsultaDGV[0, e.RowIndex].Value.ToString() + " seleccionado", "");
                Modificar mod = new Modificar(ConsultaDGV[0, e.RowIndex].Value.ToString(), Usr.K);
                mod.ShowDialog(this);
            }
            this.getCCTableAdapter1.Fill(this.browserDataSet1.GetCC);

            this.getCCTableAdapter.Fill(this.getCC._GetCC);
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        //***************** ABRE FORMULARIO QUE MUESTRA REPORTE POR USUARIOS
        private void reporte1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCount vc = new ViewCount();
            vc.Show();
        }


        //***************** MUESTRA REPORTE POR FSR 
        private void porFRSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepPorUsuario rpu = new RepPorUsuario("frs");
            rpu.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        //******************** ABRE FORM PARA CREAR LAS COPIAS CONTROLADAS
        private void copiaControladaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 CopiasControladas = new Form1();
            CopiasControladas.ShowDialog();
            this.getCCTableAdapter.Fill(this.getCC._GetCC);
        }


        private void Consultar_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet2.GetCC' Puede moverla o quitarla según sea necesario.
            this.getCCTableAdapter2.Fill(this.browserDataSet2.GetCC);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet1.GetCC' Puede moverla o quitarla según sea necesario.
            //this.getCCTableAdapter1.Fill(this.browserDataSet1.GetCC); //CAMBIAR EL ORIGEN DE DATOS HACIA EL 03
            // TODO: esta línea de código carga datos en la tabla 'getCC._GetCC' Puede moverla o quitarla según sea necesario.
            //this.getCCTableAdapter.Fill(this.getCC._GetCC);

            //MUESTRA MENUSTRIP DEPENDIENDO DEL ROL O AREA DE USUARIO
            if (Usr.Joi == 4)
            {
                cambiosToolStripMenuItem.Visible = false;
                reporte1ToolStripMenuItem.Visible = false;
            }
            if (Usr.Joi == 5 && Usr.Rick == 5)
            {
                usuariosToolStripMenuItem.Visible = true;
            }
            else
            {
                usuariosToolStripMenuItem.Visible = false;
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        //*****************ABRE FORMULARIO PARA AÑADIR UN NUEVO USUARIO
        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            am = new Admon();
            am.Set = "Nuevo";
            am.Show();
        }

        

        //****************ABRE FORMULARIO PARA HACER CAMBIOS EN LOS USUARIOS
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            am = new Admon();
            am.Set = "update";
            am.Show();
        }

        private void Consultar_Deactivate(object sender, EventArgs e)
        {
        }

        private void getCCBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}