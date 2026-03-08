using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TodolistTashkVS.Data;
using TodolistTashkVS.Models;
using TodolistTashkVS.ViewModels;

namespace TodolistTashkVS.Controllers
{
    public class AdminLoginController : Controller
    {
        private  ApplicationDbContext _context;
        private  PasswordHasher<User> _passwordHasher;

        public AdminLoginController(ApplicationDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        // GET LOGIN PAGE
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            var vm = new AdminLoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(vm);
        }

        // POST LOGIN
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == vm.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(vm);
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, vm.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(vm);
            }

            // Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = vm.RememberMe
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                authProperties);

            if (!string.IsNullOrEmpty(vm.ReturnUrl) && Url.IsLocalUrl(vm.ReturnUrl))
                return Redirect(vm.ReturnUrl);

            return RedirectToAction("Index", "Todolist");
        }

        // LOGOUT
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}