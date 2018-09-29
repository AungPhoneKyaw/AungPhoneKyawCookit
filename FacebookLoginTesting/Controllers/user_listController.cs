using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FacebookLoginTesting.Models;

namespace FacebookLoginTesting.Controllers
{
    public class user_listController : Controller
    {
        private cookingapp_latestEntities db = new cookingapp_latestEntities();

        // GET: user_list
        public ActionResult Index()
        {
            return View(db.user_list.ToList());
        }

        // GET: user_list/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_list user_list = db.user_list.Find(id);
            if (user_list == null)
            {
                return HttpNotFound();
            }
            return View(user_list);
        }

        // GET: user_list/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user_list/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userid,username,user_email")] user_list user_list)
        {
            if (ModelState.IsValid)
            {
                db.user_list.Add(user_list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_list);
        }

        // GET: user_list/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_list user_list = db.user_list.Find(id);
            if (user_list == null)
            {
                return HttpNotFound();
            }
            return View(user_list);
        }

        // POST: user_list/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userid,username,user_email")] user_list user_list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_list);
        }

        // GET: user_list/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_list user_list = db.user_list.Find(id);
            if (user_list == null)
            {
                return HttpNotFound();
            }
            return View(user_list);
        }

        // POST: user_list/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_list user_list = db.user_list.Find(id);
            db.user_list.Remove(user_list);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
