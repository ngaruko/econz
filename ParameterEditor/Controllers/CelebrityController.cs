using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParameterEditor.Models;
using PagedList;

namespace ParameterEditor.Controllers
{
    public class CelebrityController : Controller
    {
        private ParametersEntities db = new ParametersEntities();

        private const int pageSize = 50;

           
        public ActionResult Index(int page=1)
        {
            var model = db.Celebrities
            .OrderBy(b => b.Id)
          .ToPagedList(page, pageSize);

            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("_Celebrity", model)
                : View(model);

        }

        //
        // GET: /Celebrity/Details/5

        public ActionResult Details(int id = 0)
        {
            Celebrity celebrity = db.Celebrities.Find(id);
            if (celebrity == null)
            {
                return HttpNotFound();
            }
            return View(celebrity);
        }

        //
        // GET: /Celebrity/Create

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Create");
            }
            return View();
        }

        //
        // POST: /Celebrity/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Celebrity celebrity)
        {
            if (ModelState.IsValid)
            {
                db.Celebrities.Add(celebrity);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            
            return View(celebrity);


        }

        //
        // GET: /Celebrity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Celebrity celebrity = db.Celebrities.Find(id);
            if (celebrity == null)
            {
                return HttpNotFound();
            }
            else if (Request.IsAjaxRequest())
            {
                return PartialView("_Edit", celebrity);
            }

            return View(celebrity);

            //return PartialView("_Edit", celebrity);
                
        }

        //
        // POST: /Celebrity/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Celebrity celebrity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(celebrity).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            else if (Request.IsAjaxRequest())
            {
                return PartialView("_Edit", celebrity);
            }

                          
            return View(celebrity);
        }

        //
        // GET: /Celebrity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Celebrity celebrity = db.Celebrities.Find(id);
            if (celebrity == null)
            {
                return HttpNotFound();
            }

            else if (Request.IsAjaxRequest())
            {
                return PartialView("_Delete", celebrity);
            }


            return View(celebrity);
        }

        //
        // POST: /Celebrity/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Celebrity celebrity = db.Celebrities.Find(id);
            db.Celebrities.Remove(celebrity);
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