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
    public class AdoNetLoanRepository : ILoanRepository
    {
        private readonly string connString = "Server =.; Database=BibliotecaB;User ID = ticketing_usr; Password=T1cketing21;MultipleActiveResultSets=True;";

        public bool Add(Loan item)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO Loans");
                    sb.Append("(BookISBN, User, LoanDate, ReturnDate) ");
                    sb.Append("VALUES(");
                    sb.Append($"'{item.BookISBN}',");
                    sb.Append($"'{item.User}',");
                    sb.Append($"'{item.LoanDate}',");
                    sb.Append($"NULL)");

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                        return true;
                }
                catch (Exception)
                {

                }
            }

            return false;
        }

        public bool Delete(Loan item)
        {
            throw new NotImplementedException();
        }

        public List<Loan> Fetch()
        {
            List<Loan> result = new List<Loan>();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM Loans";
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Loan
                        {
                            BookISBN = reader.GetString(0),
                            User = reader.GetString(1),
                            LoanDate = reader.GetDateTime(2),
                            ReturnDate = reader["ReturnDate"] as DateTime?
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

        public Loan GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Loan item)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE Loans SET ");
                    sb.Append($"BookISDN = '{item.BookISBN}', ");
                    sb.Append($"User = '{item.User}', ");
                    sb.Append($"LoanDate = '{item.LoanDate}', ");
                    sb.Append($"ReturnDate = '{item.ReturnDate}' ");
                    sb.Append($"WHERE Id = '{item.Id}'");

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                        return true;
                }
                catch (Exception)
                {

                }
            }

            return false;
        }
    }
}
