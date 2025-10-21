using System;
using Microsoft.EntityFrameworkCore;
using WebAppUserLogin.Models;
namespace WebAppUserLogin.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
}
