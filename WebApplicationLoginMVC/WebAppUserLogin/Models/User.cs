using System;
using System.ComponentModel.DataAnnotations;
namespace WebAppUserLogin.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public DateOnly Birthdate { get; set; }
}
