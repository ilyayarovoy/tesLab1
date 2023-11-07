using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForRest_PIT
{
    [Serializable]
    public class Workers
    {
        public int id;
        public List<Worker> workers;

        public Workers()
        {
            workers = new List<Worker>();
        }

        public Workers(List<Worker> workers)
        {
            this.workers = workers;
            if (workers.Count == 0) id = 0;
            else id = workers[workers.Count - 1].id;
        }

        public int GetID()
        {
            id++;
            return id - 1;
        }

        public bool GetIndex(string login, string password, out int index)
        {
            index = -1;
            bool b = false;
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].login == login && workers[i].password == password)
                {
                    index = i;
                    b = true;
                }
            }

            return b;
        }
    }
}
