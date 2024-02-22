using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSpire
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new LogIn());
            /*Functions FT = new Functions();
            SqlDataReader Log = FT.GetRead("Select * from usuarios where Usuario='i.arruel' and Password_='123456'", FT.connectionDB);
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
            }

            Application.Run(new Form1());*/
        }
    }
}