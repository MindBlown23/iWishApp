using iWishApp.Models;

namespace iWishApp.ViewModels
{
    public class MotivationsDetailViewModel
    {
        public int MotivationsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Motivations { get; set; }

        public string CategoryTitle { get; set; }
        public string HashTagText { get; set; }


        public MotivationsDetailViewModel(Motivations theMotivations)
        {
            MotivationsId = theMotivations.Id;
            Title = theMotivations.Title;
            Description = theMotivations.Description;
            CategoryTitle = theMotivations.Category.Title;
            HashTagText = "";
            List<HashTag>evtHashTag = theMotivations.HashTag.ToList();

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
