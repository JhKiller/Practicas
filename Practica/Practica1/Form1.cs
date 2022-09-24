using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Configuration.ConfigurationManager;
namespace Practica1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "combobox")
            {

                /*   int  registrosAfectados = 0;
             Conexion.EjecutaConsulta(textBox1.Text);
             Acciones.Mensaje("Registros Afectados: " + registrosAfectados);*/
                string combo = "select " + textBox4.Text + "," + textBox5.Text + " from " + textBox6.Text;
                try
                {
                    Acciones.LlenarCombo(combo, comboBox1, textBox4.Text, textBox5.Text);
                }
                catch (Exception x)
                {

                    /*Console.WriteLine("Error: "+ x.Message);*/
                    MessageBox.Show("Error: " + x.Message);
                }
            }
            else if (comboBox2.Text == "datagridview")
            {
                
                try
                {
                    Acciones.LlenarGrid(textBox1.Text, dataGridView1);
                }
                catch (Exception x)
                {

                    /*Console.WriteLine("Error: "+ x.Message);*/
                    MessageBox.Show("Error: " + x.Message);
                }
            }
            else if (comboBox2.Text == "listview")
            {
               
                try
                {
                    Acciones.LlenarList(textBox1.Text, listView1);
                }
                catch (Exception x)
                {

                    /*Console.WriteLine("Error: "+ x.Message);*/
                    MessageBox.Show("Error: " + x.Message);
                }
            }
            else
                return;
            
              


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = "id= " + comboBox1.SelectedValue;
            }
            catch (Exception x)
            {

                /*Console.WriteLine("Error: "+ x.Message);*/
                MessageBox.Show("Error: " + x.Message);
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Text = ConnectionStrings["stringConexion"].ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "combobox")
            {
                
                textBox1.Visible = false;
                panel2.Visible = true;
                dataGridView1.Visible = false;
                listView1.Visible = false;
                panel1.Visible = true;
            }
            else if (comboBox2.Text == "datagridview")
            {
                textBox1.Visible = true;
                panel2.Visible = false;
                dataGridView1.Visible = true;
                listView1.Visible = false;
                panel1.Visible = false;
            }
            else if (comboBox2.Text == "listview")
            {
                textBox1.Visible = true;
                panel2.Visible = false;
                dataGridView1.Visible = false;
                listView1.Visible = true;
                panel1.Visible = false;
            }
            else
                return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nConexion =textBox3.Text;
            Conexion.cambiarconexion(nConexion);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
