using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_DSJ.EF;

namespace Project_DSJ.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin(Login l)
        {
            if(ModelState.IsValid)
            {
                using (SwapnilDBEntities db = new SwapnilDBEntities())
                {
                    var check = db.Logins.Where(a => a.UserName.Equals(l.UserName) && a.Password == l.Password).FirstOrDefault();
                    if(check!=null)
                    {
                        Session["LoggedUserName"] = check.UserName.ToString();
                        return RedirectToAction("Home");
                    }
                }
                
            }
            return View(l);
        }

        public ActionResult Home()
        {
            if (Session["LoggedUserName"] != null)
                return View();
            else
                return RedirectToAction("UserLogin");
        }
    }

    
}