using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForRest_PIT
{
    public class Order
    {
        public int id;
        public Buyer buyer;
        public List<Book> books;

        public Order(int id, Buyer buyer)
        {
            this.id = id;
            this.buyer = buyer;
            books = new List<Book>();
        }

        public string[] ToStringArray(out int sum)
        {
            sum = 0;
            List<string> strings = new List<string>();
            for (int i = 0; i < books.Count; i++)
            {
                strings.Add(books[i].ToString());
                sum += books[i].price;
            }

            return strings.ToArray();
        }
    }
}
