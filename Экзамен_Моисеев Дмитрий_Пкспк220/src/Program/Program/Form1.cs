using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program
{
    public partial class Form1 : Form
    {
        private string file;

        public Form1()
        {
            InitializeComponent();
        }

        private string f1(float x, float y)
        {
            if ((y == 2 * (x * x) && ((y >= 1 && y <= 2) && (x <= -(Math.Sqrt(0.5)) && x >= -1))) || 
                (y >= 1 && y <= 2 && x == -1) || (y == 1 && x <= -(Math.Sqrt(0.5)) && x >= -1))
            {
                MessageBox.Show("На границе области");
                return "На границе области";
            }
            else if ((y > 1 && y < 2) && (x < -(Math.Sqrt(0.5)) && x > -1) && (y < (2 * (x * x))))
            {
                MessageBox.Show("Точка находится внутри границ области");
                return "Точка находится внутри границ области";
            }
            else
            {
                MessageBox.Show("Точка находится вне границ области");
                return "Точка находится вне границ области";
            }
        }

        private string f2(float x, float y)
        {
            if (((x * x + y * y < 36) && !(y >= 0 && x >= 0)))
            {
                MessageBox.Show("Точка находится внутри границ области");
                return "Точка находится внутри границ области";
            }
            else if (((x * x + y * y == 36) && !(y >= 0 && x >= 0)) || (x >= 0 && x <= 6 && y == 0) || (y >= 0 && y <= 6 && x == 0))
            {
                MessageBox.Show("На границе области");
                return "На границе области";
            }
            else
            {
                MessageBox.Show("Точка находится вне границ области");
                return "Точка находится вне границ области";
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "HTML Files (.html)|*.html|All Files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;

                string[] fileName = openFileDialog1.FileName.Split('\\');
                file = fileName[fileName.Length - 1];

                webBrowser1.Navigate(openFileDialog1.FileName);
            }
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Программу разработал\nМоисеев Дмитрий Алексеевич\nстудент группы ПКспк-220\nВариант: 12\nДата разработки: 28.12.2022"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (file == "index1.html")
                {
                    toolStripStatusLabel1.Text = "";

                    toolStripStatusLabel1.Text = f1(Convert.ToSingle(textBox1.Text), Convert.ToSingle(textBox2.Text));
                }
                else if (file == "index2.html")
                {
                    toolStripStatusLabel1.Text = "";

                    toolStripStatusLabel1.Text = f2(Convert.ToSingle(textBox1.Text), Convert.ToSingle(textBox2.Text));
                }
                else
                {
                    throw new Exception("Для данной функции не найдено решение");
                }
            }
            catch (FormatException)
            {
                toolStripStatusLabel1.Text = "Должны быть вещественные числа";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = String.Format(ex.Message);
            }
        }
    }
}
