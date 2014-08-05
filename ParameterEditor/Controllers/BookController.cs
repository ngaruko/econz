using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParameterEditor.Models;
//using MvcPaging;
using PagedList;

namespace ParameterEditor.Controllers
{
    public class BookController : Controller
    {
        private ParametersEntities db = new ParametersEntities();
      
        private const int defaultPageSize = 50;

        
        
        public ActionResult Index(int page=1)
        {
            var model = db.Books
            .OrderBy(b=>b.Id)
            .ToPagedList(page, defaultPageSize);

            
          
            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("_Books",model)
                : View(model);                

    }

              //
        // GET: /Book/Details/5

        public ActionResult Details(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Create");
            }
            return View();
        }

        //
        // POST: /Book/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View(book);
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }


            else if (Request.IsAjaxRequest())
                {
                    return PartialView("_Edit",book);
                }
                
                    return View(book);
                
          }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
               // return RedirectToAction("Index");
            }

            else if (Request.IsAjaxRequest())
            {
                return PartialView("_Edit", book);
            }
            return View(book);
        }

        //
        // GET: /Book/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            else if (Request.IsAjaxRequest())
            {
                return PartialView("_Delete", book);
            }

            return View(book);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}