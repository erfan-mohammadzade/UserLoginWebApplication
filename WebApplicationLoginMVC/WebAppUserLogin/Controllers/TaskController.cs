using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

using WebAppUserLogin.Data;
using WebAppUserLogin.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAppUserLogin.Controllers;

[Authorize]
class TaskController : Controller
{
    private readonly AppDbContext _context;

    public TaskController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var username = User.Identity.Name;
        var user = await _context.Users.FirstOrDefaultAsync(ui => ui.Username == username);
        var tasks = await _context.TaskItems.Where(ti => ti.UserId == user.Id).ToListAsync();
        return View(tasks);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(TaskItem model)
    {
        var username = User.Identity.Name;
        
    }
}
    