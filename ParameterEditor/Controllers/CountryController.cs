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
    public class CountryController : Controller
    {
        private ParametersEntities db = new ParametersEntities();
        private const int pageSize = 50;
       
        //
        // GET: /Country/

        public ActionResult Index(int page=1)
        {
            var model = db.Countries
             .OrderBy(b => b.Id)
             .ToPagedList(page, pageSize);

            return Request.IsAjaxRequest()
               ? (ActionResult)PartialView("_Countries", model)
               : View(model);

        }



        //
        // GET: /Country/Details/5

        public ActionResult Details(int id = 0)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        //
        // GET: /Country/Create

        public ActionResult Create()
        {

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Create");
            }
            return View();
        }

        //
        // POST: /Country/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(country);
                db.SaveChanges();
                //return RedirectToAction("Index");
                
            }

            return View(country);
        }

        //
        // GET: /Country/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            else if (Request.IsAjaxRequest())
            {
                return PartialView("_Edit", country);
            }
            return View(country);
        }

        //
        // POST: /Country/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            else if (Request.IsAjaxRequest())
            {
                return PartialView("_Edit", country);
            }

                
            return View(country);
        }

        //
        // GET: /Country/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }

            else if (Request.IsAjaxRequest())
            {
                return PartialView("_Delete", country);
            }
            return View(country);
        }

        //
        // POST: /Country/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
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