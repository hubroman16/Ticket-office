using System;
using System.Windows.Forms;

namespace Task6._9
{
    public partial class Form2 : Form
    {
        public Form2(string id, string row, string place, string name, string time, string price, string yarus, string status)
        {
            InitializeComponent();
            textbox0.Text = id;
            textBox1.Text = row;
            textBox2.Text = place;
            textBox3.Text = name;
            textBox4.Text = time;
            textBox5.Text = price;
            textBox6.Text = yarus;
            textBox7.Text = status;
        }
    }
}
