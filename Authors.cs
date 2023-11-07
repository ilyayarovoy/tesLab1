using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForRest_PIT
{
    [Serializable]
    public class Authors
    {
        public int id;
        public List<Author> authors;

        public Authors() 
        {
            authors = new List<Author>();        
        }

        public Authors(List<Author> authors)
        {
            this.authors = authors;
            if (authors.Count == 0) id = 0;
            else id = authors[authors.Count - 1].id;
        }

        public int GetID()
        {
            id++;
            return id - 1;
        }

        public void Add(Author author)
        {
            authors.Add(author);
        }

        public void RemoveAt(int index) 
        { 
            authors.RemoveAt(index);
        }

        public string[] ToStringArray()
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < authors.Count; i++)
            {
                strings.Add(authors[i].ToString());
            }

            return strings.ToArray();
        }
    }
}
