using MVCApplication.DataAccessLayer.Repositories;
using MVCApplication.Mappers;
using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository studentRepository;
        private readonly StudentVMMapper studentVMMapper;

        public StudentController()
        {
            studentRepository = new StudentRepository();
            studentVMMapper = new StudentVMMapper();
        }

        // GET: Student
        public ActionResult Index()
        {
            if (Session["Email"] == null)
            {
                return Redirect("/User/Login");
            }

            var data = studentRepository.Get();
            var vms = studentVMMapper.Map(data);
            return View(vms);
        }

        public ActionResult Create(StudentVM student)
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ReferenceEquals(student, null) && !string.IsNullOrWhiteSpace(student.Name) && !string.IsNullOrWhiteSpace(student.RollNumber))
            {
                var entity = studentVMMapper.Map(student);
                var response = studentRepository.Save(entity);

                if (response > 0)
                {
                    return Redirect("Index");
                }
                else
                {
                    return View(student);
                }
            }

            return View(new StudentVM());
        }
    
        public ActionResult Edit(long id, StudentVM student)
        {
            if (Session["Email"] == null)
            {
                return Redirect("/User/Login");
            }

            if (!ReferenceEquals(student, null) && student.ID > 0 && !string.IsNullOrWhiteSpace(student.Name) && !string.IsNullOrWhiteSpace(student.RollNumber))
            {
                var entity = studentVMMapper.Map(student);
                var response = studentRepository.Update(entity);

                return RedirectToAction("Index");
            }
            else if (id > 0)
            {
                var entity = studentRepository.Get(id);
                var vm = studentVMMapper.Map(entity);
                return View(vm);
            }

            return View(student);
        }

        public ActionResult Details(long id)
        {
            if (Session["Email"] == null)
            {
                return Redirect("/User/Login");
            }

            if (id > 0)
            {
                var entity = studentRepository.Get(id);
                var vm = studentVMMapper.Map(entity);
                return View(vm);
            }
            return View(new StudentVM());
        }

        public ActionResult Delete(long id)
        {
            if (Session["Email"] == null)
            {
                return Redirect("/User/Login");
            }

            studentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}