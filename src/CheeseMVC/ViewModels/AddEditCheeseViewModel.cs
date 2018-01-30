using System;
using System.ComponentModel.DataAnnotations;
using CheeseMVC.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CheeseMVC.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel
    {
        public int cheeseId { get; set; }
    }
}
