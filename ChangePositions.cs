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
    public partial class ChangePositions : Form
    {
        bool groupIsSelected = false;
        int groupIndex = -1;


        public ChangePositions()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Data.Authors.ToStringArray());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupIsSelected)
            {
                if (listBox1.SelectedItems.Count > 0)
                {
                    button2.Text = "Изменить";

                    int index = listBox1.SelectedIndex;

                    textBox1.Text = Data.Authors.authors[groupIndex].books[index].name;
                    numericUpDown1.Value = Data.Authors.authors[groupIndex].books[index].price;
                }
                else
                {
                    button2.Text = "Добавить";

                    textBox1.Text = "";
                    numericUpDown1.Value = 0;
                }
            }            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupIndex = comboBox1.SelectedIndex;
            groupIsSelected = true;

            UpdateList();
        }

        public void UpdateList()
        {
            if (groupIndex >= 0)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(Data.Authors.authors[groupIndex].ToStringArray());
            }
        }

        DataBaseConnection dbc = new DataBaseConnection();

        private void button1_Click(object sender, EventArgs e)
        {
            if (groupIsSelected)
            {
                int index = listBox1.SelectedIndex;
                dbc.RemoveData(Data.Authors.authors[groupIndex].books[index]);
                Data.Authors.authors[groupIndex].books.RemoveAt(index);

                UpdateList();                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (groupIsSelected)
            {
                if (listBox1.SelectedItems.Count > 0) 
                {
                    int index = listBox1.SelectedIndex;

                    Data.Authors.authors[groupIndex].books[index].name = textBox1.Text;
                    Data.Authors.authors[groupIndex].books[index].price = (int)numericUpDown1.Value;
                    dbc.UpdateData(Data.Authors.authors[groupIndex].books[index]);

                    UpdateList();
                }
                else
                {
                    Book book = new Book(Data.BooksGetID(), textBox1.Text, (int)numericUpDown1.Value);
                    Data.Authors.authors[groupIndex].books.Add(book);
                    dbc.InsertData(book, Data.Authors.authors[groupIndex].id);
                    UpdateList();
                }
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            Manager f = new Manager();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            listBox1_SelectedIndexChanged(sender, e);
        }
    }
}
