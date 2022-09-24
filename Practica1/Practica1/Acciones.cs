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
using ListView = System.Windows.Forms.ListView;
using System.Configuration;

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
        public static void LlenarGrid(string consulta, DataGridView grid)
        {

            DataTable dt;

            dt = Conexion.EjecutaSeleccion(consulta);
            if (dt == null)
            {
                return;
            }
            grid.DataSource = dt;
        }
        public static void LlenarList(string consulta, ListView list)
        {
            list.Columns.Clear();
            list.Items.Clear();
            DataTable dt;

            dt = Conexion.EjecutaSeleccion(consulta);
            if (dt == null)
            {
                return;
            }
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                list.Columns.Add(dt.Columns[j].ColumnName);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lista = new ListViewItem(dt.Rows[i].ItemArray[0].ToString());
                for (int z = 1; z < dt.Columns.Count; z++)
                { 
                    lista.SubItems.Add(dt.Rows[i].ItemArray[z].ToString());
                }
                /*  list.Items.Add(dt.Rows[i].ItemArray[j].ToString());*/
                list.Items.Add(lista);
            }
            
        }
    }
}
