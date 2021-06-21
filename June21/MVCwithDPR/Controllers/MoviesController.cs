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
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            List<MovieModel> MvList = new List<MovieModel>();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {

                MvList = dbcon.Query<MovieModel>("select * from tbl_Movies").ToList();

            }
            return View(MvList);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            MovieModel mk = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                mk = dbcon.Query<MovieModel>("select * from tbl_Movies where Sno =" + id, new { id }).SingleOrDefault();
            }
            return View(mk);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(MovieModel mk)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                string sqlQry = "insert into tbl_Movies (Movie) Values('" + mk.Movie + "' )";
                int rowins = dbcon.Execute(sqlQry);
            }
            return RedirectToAction("Index");
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {

            MovieModel mk = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                mk = dbcon.Query<MovieModel>("select * from tbl_Movies where Sno =" + id, new { id }).SingleOrDefault();
            }
            return View(mk);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(MovieModel mk,int id)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                string sqlQuery = "update tbl_Movies set Movie='" + mk.Movie + "'where Sno=" + mk.Sno;
                int updrows = dbcon.Execute(sqlQuery);
            }
            return RedirectToAction("Index");
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BkConStr"].ConnectionString))
            {
                string Qry = "Delete from tbl_Movies where Sno =" + id;
                int delrow = dbcon.Execute(Qry);
            }
            return RedirectToAction("Index");
        }

        // POST: Movies/Delete/5
        //  [HttpPost]
        //    public ActionResult Delete(int id, FormCollection collection)
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");

        //    }
        //}
    }
}
