using System;
using System.Data;
using System.Data.SqlClient;
namespace ADOProjectExample
{
    public class Program
    {
        string conString;
        SqlConnection con;
        SqlCommand cmd;
        int Count = 0;
        public Program()
        {
            conString = @"server=LAPTOP-IC20KR9H\MSSQLSERVER2019;Integrated security=true;Initial catalog=pubs";
            con = new SqlConnection(conString);
        }

        public void FetchMoviesFromDatabase()
        {
            string strCmd = "Select *from tblMovie";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Movie Id :" + drMovies[0].ToString());
                    Console.WriteLine("Movie Name :" + drMovies[1]);
                    Console.WriteLine(" Movie Duration:" + drMovies[2].ToString());
                    Console.WriteLine("---------------------------------------------");
                    Count++;
                }
                Console.WriteLine(Count);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void FetchOneMovieFromDatabase()
        {
            string strCmd = "select * from tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                Console.WriteLine("Please enter the id");
                int id = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters[0].Value = id;
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Movie Id:" + drMovies[0].ToString());
                    Console.WriteLine("Movie Name: " + drMovies[1]);
                    Console.WriteLine("Movie Duration: " + drMovies[2].ToString());
                    Console.WriteLine("-------------------------------------");
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void AddMovie()
        {
            Console.WriteLine("Enter movie name");
            string mName = Console.ReadLine();
            Console.WriteLine("enter movie duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd = "insert into tblMovie(name,duration) values(@mname,@mdur)";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mname", mName);
            cmd.Parameters.AddWithValue("mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie inserted");
                else
                    Console.WriteLine("no  not done");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateMovieDuration()
        {
            Console.WriteLine("Please enter the Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the movie duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd = "Update tblMovie set duration =@mdur where id =@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie updated");
                else
                    Console.WriteLine("No not done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        void DeleteMovie()
        {
            Console.WriteLine("Please enter the Id");
            int id = Convert.ToInt32(Console.ReadLine());
            string strCmd = "delete from tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie deleted");
                else
                    Console.WriteLine("No not done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("!!!!MENU!!!!");
                Console.WriteLine("1.Add Movie");
                Console.WriteLine("2.Update Movie");
                Console.WriteLine("3.Delete Movie");
                Console.WriteLine("4.Display Movies List");
                Console.WriteLine("5.Exit");
                Console.WriteLine("-----------------------------------");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        new Program().AddMovie();
                        break;
                    case 2:
                        new Program().UpdateMovieDuration();
                        break;
                    case 3:
                        new Program().DeleteMovie();
                        break;
                    case 4:
                        new Program().FetchMoviesFromDatabase();
                        break;
                    case 5:
                        Console.WriteLine("Exiting");
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
            } while (choice != 5);
        }
        static void Main(string[] a)
        {
            Program program = new Program();
          //  new Program().FetchMoviesFromDatabase();
           // new Program().FetchOneMovieFromDatabase();
           //new Program().AddMovie();
          //  new Program().UpdateMovieDuration();
            //new Program().DeleteMovie();
            new Program().PrintMenu();
            Console.ReadKey();
            //Console.WriteLine("Hello World!");
        }
    }
}