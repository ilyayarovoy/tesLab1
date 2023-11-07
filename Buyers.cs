using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForRest_PIT
{
    [Serializable]
    public class Buyers
    {
        public int id;
        public List<Buyer> buyers;

        public Buyers()
        {
            buyers = new List<Buyer>();
        }

        public Buyers(List<Buyer> buyers)
        {
            this.buyers = buyers;
            if (buyers.Count == 0) id = 0;
            else id = buyers[buyers.Count - 1].id;
        }

        public int GetID()
        {
            id++;
            return id - 1;
        }

        public string[] NumberToStringArray()
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < buyers.Count; i++)
            {
                strings.Add(buyers[i].number.ToString());
            }

            return strings.ToArray();
        }

        public string[] ToStringArray()
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < buyers.Count; i++)
            {
                strings.Add(buyers[i].ToString());
            }

            return strings.ToArray();
        }

        public void Add(Buyer buyer)
        {
            buyers.Add(buyer);
        }

        public void RemoveAt(int index)
        {
            buyers.RemoveAt(index);
        }
    }
}
