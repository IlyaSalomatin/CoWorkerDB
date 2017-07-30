using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W13.Models;

namespace W13.Controllers
{
    public class CoWorkersController : Controller
    {
        private CoWorkerContext db = new CoWorkerContext();

        // GET: CoWorkers
        public ActionResult Index()
        {
            var employee = db.CoWorkers.Include(c => c.Entity).Include(c => c.Hobbys);
            return View(employee.ToList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Entitys = new SelectList(db.Entitys, "Id", "Name");
            ViewBag.Hobbys = db.Hobbys.ToList();
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(CoWorker p, int[] selectedHobbys)
        {
            if (selectedHobbys != null)
            {
                p.Hobbys = new List<Hobby>();
                var courses = db.Hobbys.Where(co => selectedHobbys.Contains(co.Id));
                foreach (var c in courses)
                {
                    p.Hobbys.Add(c);
                }
            }
            db.CoWorkers.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoWorker p= db.CoWorkers.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            ViewBag.Entitys = new SelectList(db.Entitys, "Id", "Name");
            ViewBag.Hobbys = db.Hobbys.ToList();
            return View(p);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CoWorker p, int[] selectedHobbys)
        {
            if (ModelState.IsValid)
            {
                CoWorker newP = db.CoWorkers.Find(p.Id);
                newP.Name = p.Name;
                newP.Age = p.Age;
                newP.Position = p.Position;
                newP.Entity = p.Entity;
                newP.Hobbys.Clear();
                if (selectedHobbys != null)
                {
                    var hobbys = db.Hobbys.Where(co => selectedHobbys.Contains(co.Id));
                    foreach (var c in hobbys)
                    {
                        newP.Hobbys.Add(c);
                    }
                }
                db.Entry(newP).State = EntityState.Modified;
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        // GET: CoWorkers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoWorker coWorker = db.CoWorkers.Find(id);
            ViewBag.Hobbys = coWorker.Hobbys.ToList();
            if (coWorker == null)
            {
                return HttpNotFound();
            }
            return View(coWorker);
        }

        // POST: CoWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            CoWorker coWorker = db.CoWorkers.Find(id);            
            db.CoWorkers.Remove(coWorker);
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
