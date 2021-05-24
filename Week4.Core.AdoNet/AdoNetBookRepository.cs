using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.Interfaces;
using Week4.Core.Model;

namespace Week4.Core.AdoNet
{
    public class AdoNetBookRepository : IBookRepository
    {
        private readonly string connString = "Server =.; Database=BibliotecaB;User ID = ticketing_usr; Password=T1cketing21;MultipleActiveResultSets=True;";
        
        public bool Add(Book item)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO Books");
                    sb.Append("(ISBN, Title, Summary, Author) ");
                    sb.Append("VALUES(");
                    sb.Append($"'{item.ISBN}',");
                    sb.Append($"'{item.Title}',");
                    sb.Append($"'{item.Summary}',");
                    sb.Append($"'{item.Author}')");

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                        return true;
                }
                catch (Exception ex)
                {
                    
                }
            }

            return false;
        }

        public bool Delete(Book item)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string command = $"DELETE FROM Books WHERE ISBN = '{item.ISBN}'";

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = command;

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                        return true;
                }
                catch (Exception ex)
                {

                }
            }

            return false;
        }

        public List<Book> Fetch()
        {
            List<Book> result = new List<Book>();

            using (SqlConnection connection = new SqlConnection(connString)) {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM Books";
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Book { 
                            ISBN = reader.GetString(0),
                            Title = reader.GetString(1),
                            Summary = reader.GetString(2),
                            Author = reader.GetString(3)
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Errore! => " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return result;
            }
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Book GetByISBN(string isbn)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                Book result = null;

                try {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Books WHERE ISBN = '@isbn'";
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@isbn", isbn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result = new Book
                        {
                            ISBN = reader.GetString(0),
                            Title = reader.GetString(1),
                            Summary = reader.GetString(2),
                            Author = reader.GetString(3)
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Errore! => " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
        }

            return null;
        }

        public bool Update(Book item)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE Books SET ");
                    sb.Append($"ISBN = '{item.ISBN}', ");
                    sb.Append($"Title = '{item.Title}', ");
                    sb.Append($"Summary = '{item.Summary}', ");
                    sb.Append($"Author = '{item.Author}' ");
                    sb.Append($"WHERE ISBN = '{item.ISBN}'");

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                        return true;
                }
                catch (Exception ex)
                {

                }
            }

            return false;
        }
    }
}
