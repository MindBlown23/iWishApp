using System.ComponentModel.DataAnnotations;
using iWishApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iWishApp.ViewModels
{
    public class AddMotivationsViewModel
    {
        [Required(ErrorMessage = "Title is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters long")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required!")]
        [StringLength(225, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 225 characters long")]
        public string Description { get; set; }
        
        public string Video { get; set; }
        public string Picture { get; set; }
        public MotivationsCategory Category { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public int CategoryId { get; set; }

        public int Id { get; set; }

        public List<SelectListItem>? Categories { get; set; }

        public AddMotivationsViewModel(List<MotivationsCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(
                    new SelectListItem
                    {
                        Value = category.Id.ToString(),
                        Text = category.Title
                    }
            );
            }
        }
        public AddMotivationsViewModel()
        {

        }
    }
}
