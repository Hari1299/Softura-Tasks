using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreDatabase
{
    class Program
    {
        
            public string BookSP(string title, int aid, double price)
            {
                string res = null;
                SqlConnection con = new SqlConnection("data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated security=true;");
                SqlCommand cmd = new SqlCommand("sp_InsBook", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
                //cmd.Parameters.AddWithValue("@AuthorId", SqlDbType.Int).Value = aid;
                //cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@Title";
                p1.SqlDbType = SqlDbType.NVarChar;
                p1.Value = title;
                cmd.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter();
                p2.ParameterName = "@Authorid";
                p2.SqlDbType = SqlDbType.Int;
                p2.Value = aid;
                cmd.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter();
                p3.ParameterName = "@Price";
                p3.SqlDbType = SqlDbType.Money;
                p3.Value = price;
                cmd.Parameters.Add(p3);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                res = "Success";
                return res;
            }
        public void SelectingBooks()
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated Security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from tbl_Books";
            cmd.Connection = con;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                Console.WriteLine(reader["BookID"] + " " + reader["Title"] + " " + reader["Price"].ToString());
            con.Close();
            Console.ReadLine();
        }
        public void InsertBooks()
            {
                SqlConnection con = new SqlConnection("data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated security=true;");
                //SqlCommand cmd = new SqlCommand("insert into tbl_book values('Harry Potter',3,950)",con);
                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = "insert into tbl_book values('Two States',1,650)";
                //cmd.Connection = con;
                string qry = "insert into tbl_books values(@title,@authorId,@Price)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@title", "davinci Code");
                cmd.Parameters.AddWithValue("@authorId", 7);
                cmd.Parameters.AddWithValue("@Price", 400);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Server is not working");
                }
                finally
                {
                    con.Close();
                }
            }

            public void InsertAuthor()
            {
                SqlConnection con = new SqlConnection("data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated security=true;");
                //SqlCommand cmd = new SqlCommand("insert into tbl_author values("vikram seth")",con);
                string qry = "insert into tbl_author values(@authorName)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@authorName", "Vikram Seth");
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Console.WriteLine("Server is not working");
                }
                finally
                {
                    con.Close();
                }
            }
            public void UpdateBooks()
            {
                SqlConnection con = new SqlConnection("data source=LAPTOP-IC20KR9H;database=BookDb;Integrated security=true;");
                string qry = "update tbl_books set title='davinci' where bookId = 1009";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        public void DeleteBooks()
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-IC20KR9H;Database=BooksDb;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("delete from tbl_books  where BookId=1013", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.BookSP("Sivagamiyin sabatham",2,90);
            //obj.InsertAuthor();
            //obj.UpdateBooks();
            // obj.DeleteBooks();
            //obj.SelectingBooks();
            SqlConnection con = new SqlConnection("data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated security=true;");
            SqlCommand cmd = new SqlCommand("select * from tbl_Author", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
               Console.WriteLine(rdr["BookId"] + " " + rdr["Title"] + " " + rdr["Price"].ToString());
            // Console.WriteLine(rdr["AuthorId"] + " " + rdr["AuthorName"].ToString());
            con.Close();
            Console.ReadLine();
        }
    }
}
