using iWishApp.Models;

namespace iWishApp.ViewModels
{
    public class AffirmationsDetailViewModel
    {
        public int AffirmationsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Affirmations { get; set; }

        public string CategoryName { get; set; }
        public string HashTagText { get; set; }


        public AffirmationsDetailViewModel(Affirmations theAffirmations)
        {
            AffirmationsId = theAffirmations.Id;
            Title = theAffirmations.Title;
            Description = theAffirmations.Description;
            CategoryName = theAffirmations.Category.Name;
            HashTagText = "";
            List<HashTag>evtHashTag = theAffirmations.HashTag.ToList();

            for(int i = 0; i < evtHashTag.Count; i++)
            {
                HashTagText += ("#" + evtHashTag[i].Name);
                if(i< evtHashTag.Count - 1)
                {
                    HashTagText += ", ";
                }
            }
        }

    }
}
