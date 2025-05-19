using Microsoft.AspNetCore.Mvc;
using System;
using UserRegistration.Data;
using UserRegistration.Models;
using UserRegistration.ViewModel;
using UserRegistration.Services;
using Microsoft.EntityFrameworkCore;

namespace UserRegistration.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public AccountController(ApplicationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var emailExists = await _context.Users.AnyAsync(u => u.Email == model.Email);
            if (emailExists)
            {
                ModelState.AddModelError("Email", "This email is already registered.");
                return View(model);
            }

            var user = new Users
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password 
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            await _emailService.SendRegistrationEmailAsync(user.Email, user.Name);

            return RedirectToAction("Success");
        }

        public IActionResult Success() => View();

    }
}
