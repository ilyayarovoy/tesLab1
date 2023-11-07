using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForRest_PIT
{
    [Serializable]
    public class Buyer
    {
        public int id;
        public int number;
        public string phoneNumber;

        public Buyer(int id, int number, string phoneNumber)
        {
            this.id = id;
            this.number = number;
            this.phoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"Клиент №{number}, {phoneNumber.Substring(7, 4)}";
        }
    }
}
