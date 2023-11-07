using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AppForRest_PIT
{
    public class DataBaseConnection
    {
        static string path = "DataBase.db";
        static string cs = @"URI=file:" + Application.StartupPath + "\\DataBase.db"; //database creat debug folder

        static SQLiteConnection con;
        static SQLiteCommand cmd;
        static SQLiteDataReader reader;

        public DataBaseConnection() { }

        public void CreateDB()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();

                    string sql = "CREATE TABLE \"author\" (\r\n\t\"id\"\tINTEGER NOT NULL UNIQUE,\r\n\t\"full_name\"\tTEXT NOT NULL,\r\n\tPRIMARY KEY(\"id\")\r\n)";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE \"book\" (\r\n\t\"id\"\tINTEGER NOT NULL UNIQUE,\r\n\t\"name\"\tTEXT NOT NULL,\r\n\t\"price\"\tINTEGER NOT NULL,\r\n\t\"author_id\"\tINTEGER NOT NULL,\r\n\tFOREIGN KEY(\"author_id\") REFERENCES \"author\"(\"id\"),\r\n\tPRIMARY KEY(\"id\")\r\n)";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE \"buyer\" (\r\n\t\"id\"\tINTEGER NOT NULL UNIQUE,\r\n\t\"number\"\tINTEGER NOT NULL,\r\n\t\"phoneNumber\"\tTEXT NOT NULL,\r\n\tPRIMARY KEY(\"id\")\r\n)";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE \"order\" (\r\n\t\"id\"\tINTEGER NOT NULL UNIQUE,\r\n\t\"buyer_id\"\tINTEGER NOT NULL,\r\n\tPRIMARY KEY(\"id\"),\r\n\tFOREIGN KEY(\"buyer_id\") REFERENCES \"buyer\"(\"id\")\r\n)";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE \"order_book\" (\r\n\t\"order_id\"\tINTEGER NOT NULL,\r\n\t\"book_id\"\tINTEGER NOT NULL,\r\n\tFOREIGN KEY(\"book_id\") REFERENCES \"book\"(\"id\"),\r\n\tFOREIGN KEY(\"order_id\") REFERENCES \"order\"(\"id\")\r\n)";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE \"worker\" (\r\n\t\"id\"\tINTEGER NOT NULL UNIQUE,\r\n\t\"login\"\tTEXT NOT NULL,\r\n\t\"password\"\tTEXT NOT NULL,\r\n\t\"name\"\tTEXT,\r\n\t\"surname\"\tTEXT,\r\n\t\"profession\"\tTEXT NOT NULL,\r\n\tPRIMARY KEY(\"id\")\r\n)";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE \"old_order\" (\r\n\t\"id\"\tINTEGER NOT NULL UNIQUE,\r\n\t\"buyer_id\"\tINTEGER NOT NULL,\r\n\tPRIMARY KEY(\"id\"),\r\n\tFOREIGN KEY(\"buyer_id\") REFERENCES \"buyer\"(\"id\")\r\n)";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE \"old_order_book\" (\r\n\t\"old_order_id\"\tINTEGER,\r\n\t\"book_id\"\tINTEGER,\r\n\tFOREIGN KEY(\"old_order_id\") REFERENCES \"old_order\"(\"id\"),\r\n\tFOREIGN KEY(\"book_id\") REFERENCES \"book\"(\"id\")\r\n)"; 
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void GetData()
        {
            List<Author> authors = new List<Author>();
            List<Book> books = new List<Book>();
            List<Buyer> buyers = new List<Buyer>();
            List<Order> orders = new List<Order>();
            List<Worker> workers = new List<Worker>();
            List<Order> oldOrders = new List<Order>();
                 
            var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM author";
            var cmd = new SQLiteCommand(stm, con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string fullName = reader.GetString(1);

                authors.Add(new Author(id, fullName));
            }

            stm = "SELECT * FROM book";
            cmd = new SQLiteCommand(stm, con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int price = reader.GetInt32(2);
                int authorID = reader.GetInt32(3);

                Book book = new Book(id, name, price);
                books.Add(book);

                for (int i = 0; i < authors.Count; i++)
                {
                    if (authors[i].id == authorID) authors[i].books.Add(book);
                }
            }

            stm = "SELECT * FROM buyer";
            cmd = new SQLiteCommand(stm, con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int number = reader.GetInt32(1);
                string phoneNumber = reader.GetString(2);

                buyers.Add(new Buyer(id, number, phoneNumber));
            }

            stm = "SELECT * FROM 'order'";
            cmd = new SQLiteCommand(stm, con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int buyerID = reader.GetInt32(1);
                if (id > Data.orderID) Data.orderID = id;

                Buyer buyer = new Buyer(-1, 0, "");
                for (int i = 0; i < buyers.Count; i++)
                {
                    if (buyers[i].id == buyerID) buyer = buyers[i];
                }

                orders.Add(new Order(id, buyer));
            }

            stm = "SELECT * FROM order_book";
            cmd = new SQLiteCommand(stm, con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int orderID = reader.GetInt32(0);
                int bookID = reader.GetInt32(1);

                for (int i = 0; i < orders.Count; i++)
                {
                    for (int j = 0; j < books.Count; j++)
                    {
                        if ((orders[i].id == orderID) & (books[j].id == bookID)) 
                        {
                            orders[i].books.Add(books[j]);
                        }
                    }
                }
            }

            stm = "SELECT * FROM old_order";
            cmd = new SQLiteCommand(stm, con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int buyerID = reader.GetInt32(1);
                if (id > Data.orderID) Data.orderID = id;

                Buyer buyer = new Buyer(-1, 0, "");
                for (int i = 0; i < buyers.Count; i++)
                {
                    if (buyers[i].id == buyerID) buyer = buyers[i];
                }

                oldOrders.Add(new Order(id, buyer));
            }

            stm = "SELECT * FROM old_order_book";
            cmd = new SQLiteCommand(stm, con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int orderID = reader.GetInt32(0);
                int bookID = reader.GetInt32(1);

                for (int i = 0; i < oldOrders.Count; i++)
                {
                    for (int j = 0; j < books.Count; j++)
                    {
                        if ((oldOrders[i].id == orderID) & (books[j].id == bookID))
                        {
                            oldOrders[i].books.Add(books[j]);
                        }
                    }
                }
            }

            stm = "SELECT * FROM worker";
            cmd = new SQLiteCommand(stm, con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string login = reader.GetString(1);
                string pass = reader.GetString(2);
                string name = reader.GetString(3);
                string surname = reader.GetString(4);
                string profession = reader.GetString(5);

                workers.Add(new Worker(id, login, pass, name, surname, profession));
            }

            Data.Workers = new Workers(workers);
            Data.Buyers = new Buyers(buyers);
            Data.Authors = new Authors(authors);
            Data.OldOrders = oldOrders;
            Data.Orders = orders;
            if (books.Count > 1) Data.bookID = books[books.Count - 1].id + 1;
            if (Data.orderID != 0) Data.orderID++;
        }

        public void InsertData(Author author)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"INSERT INTO author VALUES ({author.id}, '{author.fullName}')";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();
            }
        }

        public void InsertData(Book book, int authorID)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"INSERT INTO book VALUES ({book.id}, '{book.name}', {book.price}, {authorID})";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();
            }
        }

        public void InsertData(Buyer buyer)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"INSERT INTO buyer VALUES ({buyer.id}, {buyer.number}, '{buyer.phoneNumber}')";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();
            }
        }

        public void InsertData(Order order)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"INSERT INTO 'order' VALUES ({order.id}, {order.buyer.id})";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();

                for (int i = 0; i < order.books.Count; i++)
                {
                    sql = $"INSERT INTO order_book VALUES ({order.id}, {order.books[i].id})";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertOldData(Order order)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"INSERT INTO old_order VALUES ({order.id}, {order.buyer.id})";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();

                for (int i = 0; i < order.books.Count; i++)
                {
                    sql = $"INSERT INTO old_order_book VALUES ({order.id}, {order.books[i].id})";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertData(Worker worker)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"INSERT INTO worker VALUES ({worker.id}, '{worker.login}', '{worker.password}', '{worker.name}', '{worker.surname}', '{worker.profession}')";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();
            }
        }

        public void RemoveData(Author author)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"DELETE FROM author WHERE id={author.id}";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();

                sql = $"DELETE FROM book WHERE author_id={author.id}";
                command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();
            }
        }

        public void RemoveData(Book book)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"DELETE FROM book WHERE id={book.id}";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();

                sql = $"DELETE FROM order_book WHERE book_id={book.id}";
                command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();
            }
        }

        public void RemoveData(Buyer buyer)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"DELETE FROM buyer WHERE id={buyer.id}";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();
            }
        }

        public void RemoveData(Order order)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"DELETE FROM 'order' WHERE id={order.id}";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();

                sql = $"DELETE FROM order_book WHERE order_id={order.id}";
                command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateData(Book book)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"UPDATE book SET name={book.name} WHERE id={book.id}";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();

                sql = $"UPDATE book SET price={book.price} WHERE id={book.id}";
                command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateData(Order order)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql;

                sql = $"DELETE FROM order_book";
                SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                command.ExecuteNonQuery();

                for (int i = 0; i < order.books.Count; i++)
                {
                    sql = $"INSERT INTO order_book VALUES ({order.id}, {order.books[i].id})";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
