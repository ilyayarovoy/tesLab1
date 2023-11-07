using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppForRest_PIT
{
    public partial class Seller : Form
    {
        List<string> namesOfPos = new List<string>();
        int totalSum = 0;
        int orderNowIndex = -1;
        int tableIndex = -1;
        int groupIndex = -1;
        int posIndex = -1;
        List<Order> orders = Data.Orders; 

        public Seller()
        {
            InitializeComponent();

            tableNumber.Items.AddRange(Data.Buyers.NumberToStringArray());
            tableIndex = 0;
            posGroupBox.Items.AddRange(Data.Authors.ToStringArray());
            closeBoxBttn.Enabled = true;
            UpdateActualTablesList();
        }

        private void addPosBttn_Click(object sender, EventArgs e)
        {
            if (orderNowIndex == -1)
            {
                Order order = new Order(Data.OrdersGetID(), Data.Buyers.buyers[tableIndex]);
                orders.Add(order);
                orderNowIndex = orders.Count - 1;
                dbc.InsertData(order);
                UpdateActualTablesList();
            }

            if (posIndex != -1)
            {
                orders[orderNowIndex].books.Add(Data.Authors.authors[groupIndex].books[posIndex]);
                dbc.UpdateData(orders[orderNowIndex]);
                UpdatePosInOrderList();
            }
        }

        private void posGroupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePosInGroupList();
        }

        public void UpdatePosInGroupList()
        {
            if (posGroupBox.SelectedIndex >= 0)
            {
                groupIndex = posGroupBox.SelectedIndex;
                posInGroupList.Items.Clear();
                posInGroupList.Items.AddRange(Data.Authors.authors[groupIndex].ToStringArray());
            }
        }

        public void UpdatePosInOrderList()
        {
            if (orderNowIndex >= 0)
            {
                posInOrderList.Items.Clear();
                posInOrderList.Items.AddRange(orders[orderNowIndex].ToStringArray(out int sum));
                textBox1.Text = sum.ToString();
            }
        }

        public void UpdateActualTablesList()
        {
            activeTablesList.Items.Clear();
            for (int i = 0; i < orders.Count; i++)
            {                
                activeTablesList.Items.Add(orders[i].buyer.ToString());
            }
        }

        private void posInGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (posInGroupList.SelectedItems.Count > 0)
            {
                posIndex = posInGroupList.SelectedIndex;
            }
        }

        public int GetOrderIndex()
        {
            int index = -1;
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].buyer.number == Data.Buyers.buyers[tableIndex].number) index = i;
            }

            return index;
        }

        private void tableNumber_SelectedItemChanged(object sender, EventArgs e)
        {
            tableIndex = tableNumber.SelectedIndex;
            posInOrderList.Items.Clear();
            orderNowIndex = GetOrderIndex();
            UpdatePosInOrderList();
        }

        DataBaseConnection dbc = new DataBaseConnection();

        private void isPaidBttn_Click(object sender, EventArgs e)
        {
            if (orderNowIndex >= 0)
            {
                for (int i = 0; i < orders[orderNowIndex].books.Count; i++)
                {
                    namesOfPos.Add(orders[orderNowIndex].books[i].name);
                    totalSum += orders[orderNowIndex].books[i].price;
                }
                Data.OldOrders.Add(orders[orderNowIndex]);
                dbc.InsertOldData(orders[orderNowIndex]);
                dbc.RemoveData(orders[orderNowIndex]);
                orders.RemoveAt(orderNowIndex);                
                UpdateActualTablesList();
            }
        }

        private void closeBoxBttn_Click(object sender, EventArgs e)
        {
            string report = "";
            report += $"Дата: {DateToStringWithPoint(DateTime.Now)}"; report += "\r\n";
            report += $"Время выдачи отчёта: {TimeToString(DateTime.Now)}"; report += "\r\n";            
            report += $"Блюд продано: {namesOfPos.Count}"; report += "\r\n";
            report += $"Из них: "; report += "\r\n";
            foreach (string val in namesOfPos.Distinct())
            {
                report += $"{val} - {namesOfPos.Where(x => x == val).Count()}";
                report += "\r\n";
            }
            report += "\r\n";
            report += $"Общая сумма: {totalSum}";

            MessageBox.Show(report);

            Close();
        }

        public string DateToStringWithPoint(DateTime dateTime)
        {
            return $"{dateTime.Day}.{dateTime.Month}.{dateTime.Year}";
        }

        public string TimeToString(DateTime dateTime)
        {
            return $"{dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
        }

        private void activeTablesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activeTablesList.SelectedItems.Count > 0)
            {
                orderNowIndex = activeTablesList.SelectedIndex;                
                UpdatePosInOrderList();
            }
        }

        private void Seller_Load(object sender, EventArgs e)
        {

        }
    }
}
