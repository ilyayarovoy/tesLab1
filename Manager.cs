using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppForRest_PIT
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();

            UpdateList();
        }

        private void UpdateList()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Data.Buyers.ToStringArray());
            listBox2.Items.Clear();
            listBox2.Items.AddRange(Data.Authors.ToStringArray());
        }

        DataBaseConnection dbc = new DataBaseConnection();
        
        private void button1_Click(object sender, EventArgs e)
        {
            string phone = numericUpDown1.Value.ToString();
            int number = 1;
            if (Data.Buyers.buyers.Count != 0) number = Data.Buyers.buyers[Data.Buyers.buyers.Count - 1].number + 1;

            Buyer buyer = new Buyer(Data.Buyers.GetID(), number, phone);
            Data.Buyers.Add(buyer);
            dbc.InsertData(buyer);

            UpdateList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                dbc.RemoveData(Data.Buyers.buyers[listBox1.SelectedIndex]);
                Data.Buyers.RemoveAt(listBox1.SelectedIndex);                
                UpdateList();
            }
            else
            {
                MessageBox.Show("Сначала нужно выбрать стол!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Author author = new Author(Data.Authors.GetID(), textBox1.Text);
            Data.Authors.Add(author);
            dbc.InsertData(author);

            UpdateList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count > 0)
            {
                dbc.RemoveData(Data.Authors.authors[listBox2.SelectedIndex]);
                Data.Authors.RemoveAt(listBox2.SelectedIndex);                
                UpdateList();
            }
            else
            {
                MessageBox.Show("Сначала нужно выбрать вид позиции!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePositions f = new ChangePositions();
            f.Show();
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Seller f = new Seller(); 
            f.Show();
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Archive f = new Archive();
            f.Show();
            Close();
        }
    }
}
