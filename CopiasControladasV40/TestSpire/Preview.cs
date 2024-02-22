using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSpire
{
    public partial class Preview : Form
    {
        private string route;

        public string Route { get => route; set => route = value; }//Ruta al archivo pdf

        public Preview()
        {
            InitializeComponent();
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            if (Route != null)
            {
                /*Se abre una ventana con un "Navegador" que dependiendo de
                la configuración de la computadora puede mostrar el pdf en una vntana de Acrobat */
                webBrowser1.Navigate(Route);
            }
            else
            {
                this.Close();
            }
        }
    }
}