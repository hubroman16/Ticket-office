using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task6._9
{
    public partial class Form1 : Form
    {
        TicketOffice tick = new TicketOffice();
        string filename;
        public Form1(string filenames)
        {
            InitializeComponent();
            filename = filenames;
            tick.Ticketsold += Printer;//подписка
        }
        //вывод msg box
        public static void Printer(string text)
        {
            MessageBox.Show(text);
        }

        //выравнивание таблицы
        public void changedgw()
        {
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[5].Width = 60;
            dataGridView1.Columns[6].Width = 70;
        }
        //загрузка файла
        public void loadfile()
        {
            string namefile = filename;
            StreamReader file;
            try
            {
                file = new StreamReader(namefile);
                int n = Convert.ToInt32(file.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    var id = file.ReadLine();
                    var row = file.ReadLine();
                    var place = file.ReadLine();
                    var name = file.ReadLine();
                    DateTime time = DateTime.Parse(file.ReadLine());
                    var price = file.ReadLine();
                    var yarus = file.ReadLine();
                    var status = file.ReadLine();
                    var ticket = new Ticket(Convert.ToDouble(id), Convert.ToDouble(row), Convert.ToDouble(place), name, time, Convert.ToDouble(price),yarus,status);
                    tick.Add(ticket);
                    
                }
                updateData(tick.upd());
                changedgw();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            loadfile();
        }
        //обновление таблицы
        void updateData(IEnumerable<Ticket> tickets)
        {
            dataGridView1.DataSource = tickets;
        }
        //кнопки загрузки из файла
        private void fileaddbutton_Click(object sender, EventArgs e)
        {
            tick.Clear();
            loadfile();
        }
        private void addbutton2_Click(object sender, EventArgs e)
        {
            tick.Clear();
            loadfile();
        }

        private void filebutton2_Click(object sender, EventArgs e)
        {
            tick.Clear();
            loadfile();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tick.Clear();
            loadfile();
        }

        //поиск по цене
        private void pricebutton_Click(object sender, EventArgs e)
        {
            if (minbox.Text != "" & maxbox.Text != "")
            {
                double min = Convert.ToDouble(minbox.Text);
                double max = Convert.ToDouble(maxbox.Text);

                dataGridView1.DataSource = null;
                if (tick.Find_Price(min, max) != null)
                {
                    
                    dataGridView1.DataSource = tick.Find_Price(min, max);
                    changedgw();
                }
                else
                {
                    MessageBox.Show("Не найдено таких билетов!");
                }
            }
            else
            {
                MessageBox.Show("Введите диапазон цен!");
            }
        }
        //поиск по времени
        private void databutton_Click(object sender, EventArgs e)
        {
            if (databox.Text != "")
            {
                DateTime time = DateTime.Parse(databox.Text);
                dataGridView1.DataSource = null;
                if (tick.Find_Time(time) != null)
                {
                    dataGridView1.DataSource = tick.Find_Time(time);
                    changedgw();
                }
                else
                {
                    MessageBox.Show("Не найдено таких билетов!");
                }
            }
            else
            {
                MessageBox.Show("Введите искомое время!");
            }

        }
        //поиск по месту
        private void placebutton_Click(object sender, EventArgs e)
        {
            if (rowbox.Text != "" & placebox.Text!= "")
            {
                double row = Convert.ToDouble(rowbox.Text);
                double place = Convert.ToDouble(placebox.Text);

                dataGridView1.DataSource = null;
                if (tick.Find_Place(row, place) != null)
                {

                    dataGridView1.DataSource = tick.Find_Place(row, place);
                    changedgw();
                }
                else
                {
                    MessageBox.Show("Не найдено таких билетов!");
                }
            }
            else
            {
                MessageBox.Show("Введите искомое место!");
            }
        }
        //функция поиска по ярусу
        public void findyarus(string yarus)
        {
            dataGridView1.DataSource = null;
            if (tick.Find(yarus) != null)
            {
                dataGridView1.DataSource = tick.Find(yarus);
                changedgw();
            }
            else
            {
                MessageBox.Show("Не найдено таких билетов!");
            }
        }
        //сортировка по ярусу
        private void parterbutton_Click(object sender, EventArgs e)
        {
            findyarus("Партер");
        }

        private void belebutton_Click(object sender, EventArgs e)
        {
            findyarus("Бельэтаж");
        }

        private void amfibutton_Click(object sender, EventArgs e)
        {
            findyarus("Амфитеатр");
        }

        private void balkonbutton_Click(object sender, EventArgs e)
        {
            findyarus("Балкон");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1[7, dataGridView1.CurrentRow.Index].Value == "Продано")
            {
                Printer("Билет уже продан!");
            }
            else
            {
                dataGridView1[7, dataGridView1.CurrentRow.Index].Value = "Продано";
                showinfo();
                tick.soldcompleted();
            }
            
        }
        public void showinfo()
        {
            string id = Convert.ToString(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
            string row = Convert.ToString(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);
            string place = Convert.ToString(dataGridView1[2, dataGridView1.CurrentRow.Index].Value);
            string name = Convert.ToString(dataGridView1[3, dataGridView1.CurrentRow.Index].Value);
            string time = Convert.ToString(dataGridView1[4, dataGridView1.CurrentRow.Index].Value);
            string price = Convert.ToString(dataGridView1[5, dataGridView1.CurrentRow.Index].Value);
            string yarus = Convert.ToString(dataGridView1[6, dataGridView1.CurrentRow.Index].Value);
            string status = Convert.ToString(dataGridView1[7, dataGridView1.CurrentRow.Index].Value);
            Form2 newForm = new Form2(id, row, place, name, time, price, yarus, status);
            newForm.ShowDialog();
        }
        private void infobutton_Click(object sender, EventArgs e)
        {
            showinfo();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
