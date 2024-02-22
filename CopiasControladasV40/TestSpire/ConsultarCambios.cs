using DataGridViewAutoFilter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class ConsultarCambios : MaterialForm
    {
        private Functions ft = new Functions();

        public new static void DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        public ConsultarCambios()
        {
            InitializeComponent();
            DoubleBuffered(CC_DGV, true);
        }

        private void CC_DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                ft.alert("Folio " + CC_DGV[1, e.RowIndex].Value.ToString() + " seleccionado", "");
                Modificar mod = new Modificar(CC_DGV[1, e.RowIndex].Value.ToString(), Usr.K);
                mod.ShowDialog(this);
            }
            //this.Controls.Clear();
            //this.InitializeComponent();
            this.getCambiosCCTableAdapter.Fill(this.getCambiosCC._GetCambiosCC);
        }

        private void ConsultarCambios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'getCambiosCC._GetCambiosCC' Puede moverla o quitarla según sea necesario.
            this.getCambiosCCTableAdapter.Fill(this.getCambiosCC._GetCambiosCC);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            DataGridViewAutoFilterTextBoxColumn.RemoveFilter(CC_DGV);
        }

        private void CC_DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            string filterStatus = DataGridViewAutoFilterColumnHeaderCell.GetFilterStatus(CC_DGV);
            if (string.IsNullOrEmpty(filterStatus))
            {
                toolStripStatusLabel1.Visible = false;
                toolStripStatusLabel2.Visible = false;
            }
            else
            {
                toolStripStatusLabel1.Visible = true;
                toolStripStatusLabel2.Visible = true;
                toolStripStatusLabel2.Text = filterStatus;
            }
        }

        private void CC_DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt
           && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
           && CC_DGV.CurrentCell != null
           && CC_DGV.CurrentCell.OwningColumn.HeaderCell is DataGridViewAutoFilterColumnHeaderCell filterCell)
            {
                filterCell.ShowDropDownList();
                e.Handled = true;
            }
        }

        private void CC_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}