//using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Mvc.Rendering;                              m
using System;
using System.ComponentModel.DataAnnotations;

namespace iWishApp.ViewModels
{
    public class AddAffirmationsCategoryViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters long")]
        public string Name { get; set; }
    }
}
