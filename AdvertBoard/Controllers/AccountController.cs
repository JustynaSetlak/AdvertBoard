using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using AdvertBoard.Attributes;
using AdvertBoard.BusinessLogic.IdentityConfig;
using AdvertBoard.BusinessLogic.Services;
using AdvertBoard.Dtos;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AdvertBoard.Models;
using AutoMapper;

namespace AdvertBoard.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        private readonly IMapper _mapper;

        public AccountController(AuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [Anonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.LoginError = TempData["LoginError"];
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _authService.PasswordSignInAsync(model.Email, model.Password, model.RememberMe);

            if (result == SignInStatus.Success)
            {
                return RedirectToAction("GetCategories", "Category");
            }
            TempData["LoginError"] = "Invalid login attempt.";
            return RedirectToAction("Login", "Account");
        }

        [Anonymous]
        public ActionResult Register()
        {
            ViewBag.RegisterError = TempData["RegisterError"];
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _mapper.Map<RegisterViewModel, RegisterUserDto>(model);
            var result = _authService.CreateAsync(user);
            if (result.Result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            TempData["RegisterError"] = "Register process unsuccesful";
            return RedirectToAction("Register", "Account");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }
    }
}