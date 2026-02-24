using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistTashkVS.Models;

namespace TodolistTashkVS.ViewModels
{
    public class TodoListViewModel
    {
        public int Id { get; set; } //PK
      /*  public int UserId { get; set; }*/ //FK
      /*  public User User { get; set; }*/ //navigation property as per chart by vks
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;  //UtcNow add krna hai 
    }
}
