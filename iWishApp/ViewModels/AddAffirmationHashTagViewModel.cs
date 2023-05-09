using iWishApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iWishApp.ViewModels
{
    public class AddMotivationsHashTagViewModel
    {
        public int MotivationsId { get; set; }
        public Motivations? Motivations { get; set; }
        public List<SelectListItem>? HashTag { get; set; }
        public int  HashTagId { get;set; }

        public  AddMotivationsHashTagViewModel(Motivations theMotivations,List<HashTag> possibleHashTag) 
        {
            HashTag = new List<SelectListItem>();

            foreach(var hashtag in possibleHashTag) 
            {
                HashTag.Add(new SelectListItem
                {
                    Value = hashtag.Id.ToString(),
                    Text = hashtag.Name
                });
            }
            Motivations = theMotivations;
        }

        public AddMotivationsHashTagViewModel() 
        { 

        }
    }
}
