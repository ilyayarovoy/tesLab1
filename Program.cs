using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppForRest_PIT
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public static class Data
    {
        public static Worker workerNow { get; set; }
        public static Workers Workers { get; set; }
        public static Buyers Buyers { get; set; }
        public static Authors Authors { get; set; }
        public static List<Order> Orders { get; set; }

        public static List<Order> OldOrders { get; set; } = new List<Order>();
        public static int bookID { get; set; } = 0;
        public static int orderID { get; set; } = 0;
        
        public static void GetData()
        {
            DataBaseConnection dbc = new DataBaseConnection();
            dbc.CreateDB();
            dbc.GetData();
        }

        public static int BooksGetID()
        {
            bookID++;
            return bookID - 1;
        }

        public static int OrdersGetID()
        {
            orderID++;
            return orderID - 1;
        }
    }
}
