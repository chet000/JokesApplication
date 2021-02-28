using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class JokesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jokes
        public ActionResult Index()
        {
            return View(db.Jokes.ToList());
        }
        public ActionResult Showsearchform()
        {
            return View();
        }
        public ActionResult Showsearchresult(String SearchPhrase)
        {
            return View("Index",db.Jokes.ToList());
        }



        // GET: Jokes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jokes jokes = db.Jokes.Find(id);
            if (jokes == null)
            {
                return HttpNotFound();
            }
            return View(jokes);
        }
        [Authorize]

        // GET: Jokes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jokes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "Id,Jokequestion,Jokeanswer")] Jokes jokes)
        {
            if (ModelState.IsValid)
            {
                db.Jokes.Add(jokes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jokes);
        }

        // GET: Jokes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jokes jokes = db.Jokes.Find(id);
            if (jokes == null)
            {
                return HttpNotFound();
            }
            return View(jokes);
        }

        // POST: Jokes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Jokequestion,Jokeanswer")] Jokes jokes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jokes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jokes);
        }

        // GET: Jokes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jokes jokes = db.Jokes.Find(id);
            if (jokes == null)
            {
                return HttpNotFound();
            }
            return View(jokes);
        }

        // POST: Jokes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jokes jokes = db.Jokes.Find(id);
            db.Jokes.Remove(jokes);
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
