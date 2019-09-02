using IGI_5.Models;
using IGI_5.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace IGI_5.Controllers
{
    public class HomeController : Controller
    {
        Repository repository;
        int pageSize = 3;

        public HomeController(ApplicationContext context)
        {
            repository = new Repository(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        /*
        public IActionResult Schedule(int page = 1, string sort = null)
        {
            var model = repository.GetSchedules();
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("ScheduleSort", sort);
            else sort = HttpContext.Session.GetString("ScheduleSort");
            switch (sort)
            {
                case "ID": model = model.OrderBy(x => x.ID); break;
                case "Name": model = model.OrderBy(x => x.Name); break;
                case "FirmName": model = model.OrderBy(x => x.FirmName); break;
                case "Phone": model = model.OrderBy(x => x.Phone); break;
                case "Adress": model = model.OrderBy(x => x.Adress); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }
        */

        public IActionResult Class(int page = 1, string sort = null, int filter = 0)
        {
            var model = repository.GetClasses();
            if (filter > 0) HttpContext.Session.SetInt32("ClassFilter", filter);
            else filter = HttpContext.Session.GetInt32("ClassFilter") ?? 0;
            model = model.Where(x => x.Count > filter);
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("ClassSort", sort);
            else sort = HttpContext.Session.GetString("ClassSort");
            switch (sort)
            {
                case "Id": model = model.OrderBy(x => x.Id); break;
                case "ClassLead": model = model.OrderBy(x => x.ClassLead); break;
                case "Count": model = model.OrderBy(x => x.Count); break;
                case "Date": model = model.OrderBy(x => x.Date); break;
                case "ClassType": model = model.OrderBy(x => x.ClassType.Name); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }

        public IActionResult ClassType(int page = 1, string sort = null)
        {
            var model = repository.GetClassTypes();
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("ClassTypeSort", sort);
            else sort = HttpContext.Session.GetString("ClassTypeSort");
            switch (sort)
            {
                case "Id": model = model.OrderBy(x => x.Id); break;
                case "Name": model = model.OrderBy(x => x.Name); break;
                case "Description": model = model.OrderBy(x => x.Description); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }

        public IActionResult Schedule(int page = 1, string sort = null)
        {
            var model = repository.GetSchedules();
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("ScheduleSort", sort);
            else sort = HttpContext.Session.GetString("ScheduleSort");
            switch (sort)
            {
                case "Id": model = model.OrderBy(x => x.Id); break;
                case "Date": model = model.OrderBy(x => x.Date); break;
                case "Class": model = model.OrderBy(x => x.Class.ClassLead); break;
                case "Subject": model = model.OrderBy(x => x.Subject.Name); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }

        public IActionResult Student(int page = 1, string sort = null)
        {
            var model = repository.GetStudents();
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("StudentSort", sort);
            else sort = HttpContext.Session.GetString("StudentSort");
            switch (sort)
            {
                case "Id": model = model.OrderBy(x => x.Id); break;
                case "FIO": model = model.OrderBy(x => x.FIO); break;
                case "Birthday": model = model.OrderBy(x => x.Birthday); break;
                case "Gender": model = model.OrderBy(x => x.Gender); break;
                case "Class": model = model.OrderBy(x => x.Class.ClassLead); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }

        public IActionResult Subject(int page = 1, string sort = null)
        {
            var model = repository.GetSubjects();
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("SubjectSort", sort);
            else sort = HttpContext.Session.GetString("SubjectSort");
            switch (sort)
            {
                case "Id": model = model.OrderBy(x => x.Id); break;
                case "Name": model = model.OrderBy(x => x.Name); break;
                case "Description": model = model.OrderBy(x => x.Description); break;
                case "Teacher": model = model.OrderBy(x => x.Teacher); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }
    }
}