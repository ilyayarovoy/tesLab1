using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppForRest_PIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Data.GetData();
            bool b = true;
            if (Data.Workers.workers.Count > 0) b = false;            
            ViewRegistration(b);
            if (b) UnknownWorker();
        }

        public void ViewRegistration(bool b)
        {
            textBox3.Visible = b;
            textBox4.Visible = b;
            label4.Visible = b;
            label5.Visible = b;
            domainUpDown1.Visible = b;
            button3.Visible = b;
            if (b) Size = new Size(356, 402);
            else Size = new Size(356, 226);
        }

        private void UnknownWorker()
        {
            MessageBox.Show("Ваш аккаунт не найден. Давайте пройдем регистрацию!");
            ViewRegistration(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            if (Data.Workers.GetIndex(login, password, out int index)) 
            {
                MessageBox.Show("Добро пожаловать, " + Data.Workers.workers[index].name + "!");
                Data.workerNow = Data.Workers.workers[index];
                if (Data.workerNow.profession == "Менеджер") { Manager f = new Manager(); f.Show(); }
                else { Seller f = new Seller(); f.Show(); }
            }
            else
            {
                UnknownWorker();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataBaseConnection dbc = new DataBaseConnection();

            string login = textBox1.Text;
            string password = textBox2.Text;
            string name = textBox3.Text;
            string surname = textBox4.Text;
            string profession = domainUpDown1.Text;

            Worker worker = new Worker(Data.Workers.GetID(), login, password, name, surname, profession);
            Data.Workers.workers.Add(worker);
            dbc.InsertData(worker);
            Data.workerNow = worker;
            MessageBox.Show("Добро пожаловать, " + Data.workerNow.name + "!");
            if (Data.workerNow.profession == "Менеджер") { Manager f = new Manager(); f.Show(); }
            else { Seller f = new Seller(); f.Show(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
