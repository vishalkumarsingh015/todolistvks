using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistTashkVS.Data;
using TodolistTashkVS.ViewModels;

namespace TodolistTashkVS.Controllers
{

  
    public class RegisterController : Controller
    {
        private ApplicationDbContext _context;

        public RegisterController (ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        



    }

}
