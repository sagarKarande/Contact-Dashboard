using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication2.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        private readonly IAuthentication _repository;
        public AuthenticationController(IAuthentication repository)
        {
            _repository = repository;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel user, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_repository.Login(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("ListContact", "Contact");
                    }
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                if (!_repository.CheckUserExist(userModel.Username))
                {
                    user.Username = userModel.Username;
                    user.Password = userModel.Password;
                    if (_repository.register(user))
                    {
                        return RedirectToAction("Login");
                    }
                }
                else {
                    this.ViewBag.Message = "UserName Aleary Exist";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
