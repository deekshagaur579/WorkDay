using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkDayApplication.Models;

namespace WorkDayApplication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[NoCache]
        public ActionResult Login(Login model)
        {
            //try
            //{
                // Verification.    
                    Login objUser = new Login();
                    bool loginValid = objUser.ValidateLogin(model.LoginName, model.Password);
            // Verification.    
            if (loginValid)
            {
                //HttpContext.Session.SetString("StudentName", "test");
                
            }
            else
            {
                // Setting.    
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }
            //}
            //catch (Exception ex)
            //{
            //    // Info    
            //    DataNova.Utility.DNLog.AddLogEntry("Login Exception:" + ex);
            //    //Console.Write(ex);
            //    //return Content(ex.Message);
            //    ModelState.AddModelError(string.Empty, "Invalid username or password.");
            //}
            // If we got this far, something failed, redisplay form    
            return this.View(model);
        }
    }
}
