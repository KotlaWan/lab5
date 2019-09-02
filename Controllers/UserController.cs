using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGI_5.Models;
using IGI_5.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IGI_5.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class UserController : Controller
    {
        Repository repository;
                     
        public UserController(ApplicationContext context)
        {
            repository = new Repository(context);
        }
        
        
        [HttpGet]
        public ActionResult AddClass()
        {
            ViewBag.ClassTypes = repository.GetClassTypes();
            return View();
        }
        [HttpGet]
        public ActionResult EditClass(int id)
        {
            var model = repository.GetClasses().FirstOrDefault(x => x.Id == id);
            ViewBag.ClassTypes = repository.GetClassTypes();
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveClass(int id)
        {
            var model = repository.GetClasses().FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult AddClass(Class clas, string classTypes)
        {
            if (ModelState.IsValid)
            {
                clas.ClassType = repository.GetClassTypeByName(classTypes);
                repository.AddClass(clas);
                return RedirectToAction("Class", "Home");
            }
            ViewBag.ClassTypes = repository.GetClassTypes();
            return View(clas);
        }
        [HttpPost]
        public ActionResult EditClass(Class clas, string classTypes)
        {
            if (ModelState.IsValid)
            {
                clas.ClassType = repository.GetClassTypeByName(classTypes);
                repository.EditClass(clas);
                ViewBag.ClassTypes = repository.GetClassTypes();
                return RedirectToAction("Class", "Home");
            }
            return View(clas);
        }
        [HttpPost]
        public ActionResult RemoveClasses(int id)
        {
            repository.RemoveClass(id);
            return RedirectToAction("Class", "Home");
        }

        [HttpGet]
        public ActionResult AddClassType()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditClassType(int id)
        {
            var model = repository.GetClassTypes().FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveClassType(int id)
        {
            var model = repository.GetClassTypes().FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult AddClassType(ClassType classType)
        {
            if (ModelState.IsValid)
            {
                repository.AddClassType(classType);
                return RedirectToAction("ClassType", "Home");
            }
            return View(classType);
        }
        [HttpPost]
        public ActionResult EditClassType(ClassType classType)
        {
            if (ModelState.IsValid)
            {
                repository.EditClassType(classType);
                return RedirectToAction("ClassType", "Home");
            }
            return View(classType);
        }
        [HttpPost]
        public ActionResult RemoveClassTypes(int id)
        {
            repository.RemoveClassType(id);
            return RedirectToAction("ClassType", "Home");
        }

        [HttpGet]
        public ActionResult AddSchedule()
        {
            ViewBag.Classes = repository.GetClasses();
            ViewBag.Subjects = repository.GetSubjects();
            return View();
        }
        [HttpGet]
        public ActionResult EditSchedule(int id)
        {
            var model = repository.GetSchedules().FirstOrDefault(x => x.Id == id);
            ViewBag.Classes = repository.GetClasses();
            ViewBag.Subjects = repository.GetSubjects();
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveSchedule(int id)
        {
            var model = repository.GetSchedules().FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSchedule(Schedule schedule, string classes, string subjects)
        {
            if (ModelState.IsValid)
            {
                schedule.Class = repository.GetClassByName(classes);
                schedule.Subject = repository.GetSubjectByName(subjects);
                repository.AddSchedule(schedule);
                return RedirectToAction("Schedule", "Home");
            }
            ViewBag.Classes = repository.GetClasses();
            ViewBag.Subjects = repository.GetSubjects();
            return View(schedule);
        }
        [HttpPost]
        public ActionResult EditSchedule(Schedule schedule, string classes, string subjects)
        {
            if (ModelState.IsValid)
            {
                schedule.Class = repository.GetClassByName(classes);
                schedule.Subject = repository.GetSubjectByName(subjects);
                repository.EditSchedule(schedule);
                ViewBag.Classes = repository.GetClasses();
                ViewBag.Subjects = repository.GetSubjects();
                return RedirectToAction("Schedule", "Home");
            }
            return View(schedule);
        }
        [HttpPost]
        public ActionResult RemoveSchedules(int id)
        {
            repository.RemoveSchedule(id);
            return RedirectToAction("Schedule", "Home");
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            ViewBag.Classes = repository.GetClasses();
            return View();
        }
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var model = repository.GetStudents().FirstOrDefault(x => x.Id == id);
            ViewBag.Classes = repository.GetClasses();
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveStudent(int id)
        {
            var model = repository.GetStudents().FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult AddStudent(Student student, string classes)
        {
            if (ModelState.IsValid)
            {
                student.Class = repository.GetClassByName(classes);
                repository.AddStudent(student);
                return RedirectToAction("Student", "Home");
            }
            ViewBag.Classes = repository.GetClasses();
            return View(student);
        }
        [HttpPost]
        public ActionResult EditStudent(Student student, string classes)
        {
            if (ModelState.IsValid)
            {
                student.Class = repository.GetClassByName(classes);
                repository.EditStudent(student);
                ViewBag.Classes = repository.GetClasses();
                return RedirectToAction("Student", "Home");
            }
            return View(student);
        }
        [HttpPost]
        public ActionResult RemoveStudents(int id)
        {
            repository.RemoveStudent(id);
            return RedirectToAction("Student", "Home");
        }

        [HttpGet]
        public ActionResult AddSubject()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditSubject(int id)
        {
            var model = repository.GetSubjects().FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveSubject(int id)
        {
            var model = repository.GetSubjects().FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSubject(Subject subject)
        {
            if (ModelState.IsValid)
            {
                repository.AddSubject(subject);
                return RedirectToAction("Subject", "Home");
            }
            return View(subject);
        }
        [HttpPost]
        public ActionResult EditSubject(Subject subject)
        {
            if (ModelState.IsValid)
            {
                repository.EditSubject(subject);
                return RedirectToAction("Subject", "Home");
            }
            return View(subject);
        }
        [HttpPost]
        public ActionResult RemoveSubjects(int id)
        {
            repository.RemoveSubject(id);
            return RedirectToAction("Subject", "Home");
        }
    }
}