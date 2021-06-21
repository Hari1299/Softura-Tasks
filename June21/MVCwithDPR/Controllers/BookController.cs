using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCusingDPR.Models;
using System.Data;
using System.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace MVCusingDPR.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<BookModel> BkList = new List<BookModel>();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                BkList = dbcon.Query<BookModel>("select * from tbl_Books").ToList();
            }
            return View(BkList);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            BookModel bk = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                bk = dbcon.Query<BookModel>("select * from tbl_Books where bookId =" + id, new { id }).SingleOrDefault();
            }
            return View(bk);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookModel bmodel)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                string sqlQry = "insert into tbl_Books(Title,AuthorId,Price) " + " Values('" + bmodel.Title + "'," + bmodel.AuthorId + "," + bmodel.Price + ")";
                int rowins = dbcon.Execute(sqlQry);
            }
            return RedirectToAction("Index");

        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {

            BookModel bk = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                bk = dbcon.Query<BookModel>("select * from tbl_Books where bookId =" + id, new { id }).SingleOrDefault();
            }
            return View(bk);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookModel bk)
        {
            // TODO: Add update logic here
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                string sqlQuery = "update tbl_Books set Title='" + bk.Title +"',AuthorId=" + bk.AuthorId + ",Price=" + bk.Price + "where BookId=" + bk.BookId;
                int updrows = dbcon.Execute(sqlQuery);
            }
                return RedirectToAction("Index");
            
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                string Qry = "Delete from tbl_Books where BookId =" + id;
                int delrow = dbcon.Execute(Qry);
            }
           

            return RedirectToAction("Index");
        } 

        // POST: Book/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
        //    {
        //        string sqlQry="delete from tbl_Books where BookId"+id;
        //        int delins = dbcon.Execute(sqlQry);
        //    }
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
            
            
        //}
    }
}
