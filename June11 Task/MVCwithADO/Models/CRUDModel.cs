using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCwithADO.Models
{
    public class CRUDModel
    {
        public DataTable DisplayBook()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("select BookId, Title, AuthorId, Price from tbl_Books", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int NewBook(string Title, int Aid,double Price)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated Security=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@AuthorId", Aid);
            cmd.Parameters.AddWithValue("@Price", Price);
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable DisplayAuthors()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("select AuthorId, AuthorName from tbl_Author", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int NewAuthors(int Aid, string AuthorName)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated Security=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertAuthor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName",AuthorName);
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable BookbyId(int bookid)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated Security=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_books where bookId=" + bookid, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
               
        }
        public int UpdateBook(int Bid,string Title,int Aid,double Price)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated Security=true;");
            con.Open();
            string sqlqry = "Update tbl_books set Title=@title,AuthorId=@aid, Price=@price where BookId=@bookid";
            SqlCommand cmd = new SqlCommand(sqlqry, con);
            cmd.Parameters.AddWithValue("@title", Title);
            cmd.Parameters.AddWithValue("@aid", Aid);
            cmd.Parameters.AddWithValue("@price", Price);
            cmd.Parameters.AddWithValue("@bookid", Bid);
            return cmd.ExecuteNonQuery();
        }
        public int DeleteBook(int bookid)
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated security=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_books where bookid=@bkid", con);
            cmd.Parameters.AddWithValue("bkid", bookid);
            return cmd.ExecuteNonQuery();
        }

        public int SelectByAuName(string authorname)
        {
            SqlConnection con = new SqlConnection("data source=LAPTOP-IC20KR9H;database=BooksDb;Integrated security=true;");
            SqlCommand cmd = new SqlCommand("select authorId from tbl_author where AuthorName='" + authorname + "'", con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return Convert.ToInt32(s);
        }
    }
}