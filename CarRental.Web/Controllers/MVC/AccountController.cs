using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using CarRental.Web.Core;
using WebMatrix.WebData;
using CarRental.Web.Models;

namespace CarRental.Web.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountController : ViewControllerBase
    {
        [ImportingConstructor]
        public AccountController(ISecurityAdapter securityAdapter)
        {
            _SecurityAdapter = securityAdapter;
        }

        ISecurityAdapter _SecurityAdapter;

        [HttpGet]
        [GET("account/register")]
        public ActionResult Register()
        {
            _SecurityAdapter.Initialize();
            
            return View();
        }

        [HttpGet]
        [GET("account/login")]
        public ActionResult Login(string returnUrl)
        {
            _SecurityAdapter.Initialize();

            return View(new AccountLoginModel() { ReturnUrl = returnUrl });
        }

        [HttpGet]
        [GET("account/logout")]
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [GET("account/changepassword")]
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }
        
        [HttpGet]
        [GET("account/forgotpassword")]
        [Authorize]
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}
