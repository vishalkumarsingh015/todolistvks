using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistTashkVS.ViewModels
{
    public class AddTagViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tag name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Color is required")]
        public string Color { get; set; }
        public int TodoListId { get; set; }
    }
}
