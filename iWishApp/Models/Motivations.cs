using System;

namespace iWishApp.Models
{
    public class Motivations
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public string Video { get;set; }
        public MotivationsCategory Category { get; set; }

        public int CategoryId { get; set; }

        public int Id { get; set; }

        public ICollection<HashTag>? HashTag { get; set; }

        public Motivations(string title, string description, string picture) 
        {
            Title = title;
            Description = description;
            Picture = picture;
            Video = Video;
            HashTag = new List<HashTag>();
        }
        public Motivations() 
        {

        }
        public override string ToString()
        {
            return Title;
        }

        public override bool Equals(object obj) 
        {
            return obj is Motivations @Motivations
                && Id == @Motivations.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
