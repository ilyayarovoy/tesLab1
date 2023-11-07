using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForRest_PIT
{
    [Serializable]
    public class Worker
    {
        public int id;
        public string login;
        public string password;
        public string name;
        public string surname;
        public string profession;

        public Worker(int id, string login, string password, string name, string surname, string profession)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.profession = profession;
        }
    }
}
