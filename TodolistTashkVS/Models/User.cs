using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TodolistTashkVS.Models
{


    public class User
    {
        public int Id { get; set; } //PK
        public required string Name { get; set; } 
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<TodoList> TodoLists { get; set; } = new HashSet<TodoList>();




    }





}
