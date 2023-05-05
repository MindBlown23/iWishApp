using iWishApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iWishApp.ViewModels
{
    public class AddAffirmationHashTagViewModel
    {
        public int AffirmationId { get; set; }
        public Affirmations? Affirmations { get; set; }
        public List<SelectListItem>? HashTag { get; set; }
        public int  HahTagId { get;set; }

        public  AddAffirmationHashTagViewModel(Affirmations theAffirmations,List<HashTag> possibleHashTag) 
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
            Affirmations = theAffirmations;
        }

        public AddAffirmationHashTagViewModel() 
        { 

        }
    }
}
