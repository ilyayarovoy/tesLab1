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
    public partial class Archive : Form
    {
        public Archive()
        {
            InitializeComponent();

            domainUpDown1.Items.Clear();
            for (int i = 0; i < Data.OldOrders.Count; i++)
            {
                domainUpDown1.Items.Add($"Заказ №{Data.OldOrders[i].id}");
            }
        }

        private void UpdateList()
        {
            listBox1.Items.Clear();
            if (order != null)
            {
                int sum = 0;

                for (int i = 0; i < order.books.Count; i++)
                {
                    listBox1.Items.Add(order.books[i].ToString());
                    sum += order.books[i].price;
                }

                textBox2.Text = order.buyer.phoneNumber.ToString();
                textBox1.Text = sum.ToString();
            }
        }

        Order order = null;

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            order = Data.OldOrders[domainUpDown1.SelectedIndex];
            UpdateList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
            Manager f = new Manager();
            f.Show();
        }
    }
}
