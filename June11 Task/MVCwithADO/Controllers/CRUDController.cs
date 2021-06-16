using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCwithADO.Models;

namespace MVCwithADO.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            CRUDModel mdl = new CRUDModel();
           DataTable dt= mdl.DisplayBook();
            return View("Home",dt);
        }

        public ActionResult Author()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthors();
            return View("Home1", dt);
        }

        public ActionResult Insert()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthors();
            return View("Create",dt);
        }

        public ActionResult InsertRecord(FormCollection frm,string action)
        {
            if(action=="Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string Title = frm["txtTitle"];
                string Aname = frm["txtAuName"];
                int aid = mdl.SelectByAuName(Aname);
                double price = Convert.ToDouble(frm["txtprice"]);
                int rowIns = mdl.NewBook(Title, aid, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Insert1()
        {
            return View("Create1");
        }
        public ActionResult InsertAuthor(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                int aid = Convert.ToInt32(frm["txtAid"]);
                string AuthorName = (frm["txtAuName"]);
                int rowIns = mdl.NewAuthors(aid, AuthorName);
                return RedirectToAction("Author");
            }
            else
            {
                return RedirectToAction("Author");
            }
        }

          public ActionResult Update(FormCollection frm,string action)
        {
            if(action =="Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string title = frm["txtTitle"];
                int aid = Convert.ToInt32(frm["txtAid"]);
                double price = Convert.ToDouble(frm["txtPrice"]);
                int bookid = Convert.ToInt32(frm["txtBid"]);
                int updrow = mdl.UpdateBook(bookid, title, aid, price);
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int BookId)
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.BookbyId(BookId);
            return View("Edit",dt);
        }

            public ActionResult Delete(int Bookid)
            {
                CRUDModel mdl = new CRUDModel();
                mdl.DeleteBook(Bookid);
                return RedirectToAction("Index");
            }
         
        
    }
}