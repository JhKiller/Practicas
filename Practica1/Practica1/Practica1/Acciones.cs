using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;
using System.Reflection;

namespace Practica1
{
    internal class Acciones
    {
        public static void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso!",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        
        public static void LlenarCombo(string consulta, ComboBox combo, string Id, string Dato)
        {

            DataTable dt;
            
            dt = Conexion.EjecutaSeleccion(consulta);
            if (dt == null)
            {
                return;
            }
           /* dt.Rows.Add(new Object[] { 0, "Todos" });*/
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "Todos";
            dt.Rows.InsertAt(dr, 0);
           
            

            
            combo.DataSource = dt;

            combo.ValueMember = Id;
            combo.DisplayMember = Dato;

            
           /* for (int i = 0; i < dt.Rows.Count; i++)
            {
                combo.Items.Add(dt.Rows[i].ItemArray[1].ToString());
             
            }*/
        }

    }
}
