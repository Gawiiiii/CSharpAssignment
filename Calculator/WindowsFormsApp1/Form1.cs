using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[]
            {
                "请选择运算符",
                "+",
                "-",
                "*",
                "/"
            });
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int comboChosen = comboBox1.SelectedIndex;
            double num1, num2;
            if(double.TryParse(textBox1.Text, out num1) &&  double.TryParse(textBox2.Text, out num2))
            {
                double res = 0;
                try
                {
                    switch (comboChosen)
                    {
                        case 1:
                            res = num1 + num2;
                            break;
                        case 2:
                            res = num2 - num1;
                            break;
                        case 3:
                            res = num1 * num2;
                            break;
                        case 4:
                            if (num2 == 0)
                            {
                                MessageBox.Show("除数不能为0！");
                                return;
                            }
                            else
                            {
                                res = num1 / num2;
                            }
                            break;
                        default:
                            MessageBox.Show("请选择运算符！");
                            return;
                    }
                    label2.Text = $"{res}";
                }catch(Exception ex)
                {
                    MessageBox.Show($"计算出错：{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("请输入有效的数字！");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
