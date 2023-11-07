using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForRest_PIT
{
    [Serializable]
    public class Author
    {
        public int id;
        public string fullName;
        public List<Book> books;

        public Author(int id, string fullName)
        {
            this.id = id;
            this.fullName = fullName;
            books = new List<Book>();
        }

        public string[] ToStringArray()
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < books.Count; i++)
            {
                strings.Add(books[i].ToString());
            }

            return strings.ToArray();
        }

        public override string ToString()
        {
            return $"{fullName}: {books.Count} книг";
        }
    }
}
