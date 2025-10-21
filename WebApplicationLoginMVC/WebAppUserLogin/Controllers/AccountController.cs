using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using System.Security.Claims;
using WebAppUserLogin.Data;
using WebAppUserLogin.Models;

using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Azure.Identity;
namespace WebAppUserLogin.Controllers;

public class AccountController : Controller
{
    private readonly AppDbContext _context;
    public AccountController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var hash = HashPassword(password);
        var user = await _context.Users.FirstOrDefaultAsync(ui => ui.Username == username && ui.Password == hash);
        if (user == null)
        {
            ViewBag.Error = "Invalid username or password";
            return View();
        }

        var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username) };
        var identity = new ClaimsIdentity(claims, "MyCookiAuth");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("NyCookiAuth", principal);
        return RedirectToAction("index", "Panel");
    }
    [HttpGet]
    public IActionResult Register() => View();
    [HttpPost]
    public async Task<IActionResult> Register(string username, string password)
    {
        if (await _context.Users.AnyAsync(ui => ui.Username == username))
        {
            ViewBag.Error("User already Exist");
            return View();
        }

        var user = new User { Username = username, Password = HashPassword(password) };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("Loign");
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("MyCookieAuth");
        return RedirectToAction("Login");
    }
    private string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }
}
