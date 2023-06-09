using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task6._9
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void placebutton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Form1 main = new Form1("ticketlist1.txt");
                main.Show();
                this.Hide();
            }
            else
            {
                Form1 main = new Form1("ticketlist.txt");
                main.Show();
                this.Hide();
            }
        }
    }
}
