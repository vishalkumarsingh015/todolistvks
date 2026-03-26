using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistTashkVS.ViewModels
{
    public class AddTagPageViewModel
    {
        public AddTagViewModel NewTag { get; set; }
        public List<AddTagViewModel> Tags { get; set; }
    }
}
