//using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Mvc.Rendering;                          
using System;
using System.ComponentModel.DataAnnotations;

namespace iWishApp.ViewModels
{
    public class AddMotivationsCategoryViewModel
    {
        [Required(ErrorMessage = "Title is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 20 characters long")]
        public string Title { get; set; }
    }
}
