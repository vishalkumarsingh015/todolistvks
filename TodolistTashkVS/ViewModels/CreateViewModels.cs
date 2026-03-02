using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistTashkVS.ViewModels
{
    public class CreateViewModels
    {
        [Display(Name = "Titles")]  
        [Required(ErrorMessage ="Title Field can not be nulll")]  //client side validation
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int userId { get; set; }
    }
}
