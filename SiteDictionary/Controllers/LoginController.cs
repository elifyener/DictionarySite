using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SiteDictionary.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            AdminValidator wv = new AdminValidator();
            ValidationResult results = wv.Validate(p);
            if (results.IsValid)
            {
                Context c = new Context();
                var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
                if (adminuserinfo != null)
                {
                    FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                    Session["AdminUserName"] = adminuserinfo.AdminUserName;
                    return RedirectToAction("Index", "AdminCategory");
                }
                else
                {
                    ViewBag.errPass = true;
                    return View();
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            WriterLoginValidator wv = new WriterLoginValidator();
            ValidationResult results = wv.Validate(p);
            if (results.IsValid)
            {
                var writeruserinfo = wlm.GetWriter(p.WriterMail, p.WriterPassword);
                if (writeruserinfo != null)
                {
                    FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                    Session["WriterMail"] = writeruserinfo.WriterMail;
                    return RedirectToAction("MyContent", "WriterPanelContent");
                }
                else
                {
                    ViewBag.errPass = true;
                    return View();
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }

}
