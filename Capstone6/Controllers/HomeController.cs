using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone6.Models;

namespace Capstone6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult TaskList()
        {
            TaskListDBEntities ORM = new TaskListDBEntities();
            ViewBag.Tasks = ORM.Tasks.ToList<Task>();
            return View();
        }
        public ActionResult UpdateComplete(int taskID)
        {
            TaskListDBEntities ORM = new TaskListDBEntities();
            Task oldTask = ORM.Tasks.Find(taskID);
            if (oldTask.Complete == false)
            {
                oldTask.Complete = true;
                ORM.Entry(oldTask).State = System.Data.Entity.EntityState.Modified;
                ORM.SaveChanges();
                return RedirectToAction("TaskList");
            }
            else
            {
                return RedirectToAction("TaskList");
            }
            

        }
        public ActionResult DeleteTask(int taskID)
        {
            TaskListDBEntities ORM = new TaskListDBEntities();
            Task found = ORM.Tasks.Find(taskID);
            ORM.Tasks.Remove(found);
            ORM.SaveChanges();
            return RedirectToAction("TaskList");

        }
        public ActionResult AddTask()
        {
            return View();
        }
        public ActionResult AddNewTask(Task newTask)
        {
            if (ModelState.IsValid)
            {
                TaskListDBEntities ORM = new TaskListDBEntities();
                Task oldTask = ORM.Tasks.Add(newTask);
                ORM.SaveChanges();
                return RedirectToAction("TaskList");

            }
            else
            {
                ViewBag.Error = "Error with adding task.";
                return View("AddTask");
            }
        }

    }
}