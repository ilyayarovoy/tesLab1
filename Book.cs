using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForRest_PIT
{
    [Serializable]
    public class Book
    {
        public int id;
        public string name;
        public int price;

        public Book(int id, string name, int price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        public override string ToString()
        {
            return $"'{name}', {price} рублей";
        }
    }
}
