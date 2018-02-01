using BugTracker.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FluentMvc.App.Controllers
{
    public class BugsController : Controller
    {
        private BugTrackerContext db = new BugTrackerContext();

        // GET: Bugs
        public ActionResult Index()
        {
            return View(db.Bugs.ToList());
        }

        // GET: Bugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            return View(bug);
        }

        // GET: Bugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status,Text,DateCreated")] Bug bug)
        {
            if (ModelState.IsValid)
            {
                db.Bugs.Add(bug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bug);
        }

        // GET: Bugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            return View(bug);
        }

        // POST: Bugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status,Text,DateCreated")] Bug bug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bug);
        }

        // GET: Bugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            return View(bug);
        }

        // POST: Bugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bug bug = db.Bugs.Find(id);
            db.Bugs.Remove(bug);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ToJson()
        {
            return Json(db.Bugs.ToList());
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
