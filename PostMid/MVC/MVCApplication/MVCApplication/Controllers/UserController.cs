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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginVM loginCreds, string redirectUrl)
        {
            ViewBag.Title = "Login";

            if (Session["Name"] != null)
            {
                return Redirect("~/Student");
            }

            if (loginCreds != null && !string.IsNullOrWhiteSpace(loginCreds.Email) && !string.IsNullOrWhiteSpace(loginCreds.Password))
            {
                var repo = new UserRepository();
                var user = repo.Check(loginCreds.Email, loginCreds.Password);

                if (user != null)
                {
                    Session["Name"] = user.Name;
                    Session["Email"] = user.Email;

                    return Redirect("/Student");
                }
                else
                {
                    ViewBag.Error = "Invalid credentials";
                    return View();
                }
            }

            return View();
        }

        public ActionResult LogOut()
        {
            Session["Name"] = null;
            Session["Email"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult List()
        {
            var entities = new UserRepository().Get();
            var vms = new UserVMMapper().Map(entities);
            return View(vms);
        }

        public ActionResult UpdatePassword(long id, UserVM incomingUser)
        {
            var repo = new UserRepository();
            var mapper = new UserVMMapper();

            if (incomingUser != null && !String.IsNullOrWhiteSpace(incomingUser.Password))
            {
                var entity = repo.UpdatePassword(id, incomingUser.Password);
                if (entity == null)
                {
                    ViewBag.Message = "Failure";
                }
                else
                {
                    ViewBag.Message = "Success";
                    var _vm = mapper.Map(entity);
                    return View(_vm);
                }
            }

            var user = repo.Get(id);
            var vm = mapper.Map(user);

            return View(vm);
        }
    }
}