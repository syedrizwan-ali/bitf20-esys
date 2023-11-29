using MVCApplication.DataAccessLayer.Repositories;
using MVCApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var repo = new StudentRepository();
            var data = repo.Get();
            var mapper = new StudentVMMapper();
            var vms = mapper.Map(data);
            return View(vms);
        }
    }
}