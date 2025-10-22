using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppUserLogin.Models;

public class TaskItem
{
    [Key]
    public int Taskid { get; set; }
    [Required]
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime Createdate { get; set; }
    
    [ForeignKey("User")]
    public User User { get; set; }
    public int UserId { get; set; }
}
