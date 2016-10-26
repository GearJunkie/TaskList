
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskList;
using TaskList.DAL;
using TaskList.Models;

namespace TaskList.Controllers
{
    public class TodoTasksController : Controller
    {
        private TodoTaskDbContext db = new TodoTaskDbContext();

        // GET: TodoTasks
        public ActionResult Index()
        {
            var todoTasks = db.TodoTasks.Include(t => t.Lists);
            return View(todoTasks.ToList());
        }

        // GET: TodoTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoTask todoTask = db.TodoTasks.Find(id);
            if (todoTask == null)
            {
                return HttpNotFound();
            }
            return View(todoTask);
        }

        // GET: TodoTasks/Create
        public ActionResult Create()
        {
            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName");
            return View();
        }

        // POST: TodoTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TodoTaskID,Task,ListID,completed")] TodoTask todoTask)
        {
            if (ModelState.IsValid)
            {
                db.TodoTasks.Add(todoTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName", todoTask.ListID);
            return View(todoTask);
        }

        // GET: TodoTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoTask todoTask = db.TodoTasks.Find(id);
            if (todoTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName", todoTask.ListID);
            return View(todoTask);
        }

        // POST: TodoTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TodoTaskID,Task,ListID,completed")] TodoTask todoTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName", todoTask.ListID);
            return View(todoTask);
        }

        // GET: TodoTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoTask todoTask = db.TodoTasks.Find(id);
            if (todoTask == null)
            {
                return HttpNotFound();
            }
            return View(todoTask);
        }

        // POST: TodoTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TodoTask todoTask = db.TodoTasks.Find(id);
            db.TodoTasks.Remove(todoTask);
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
