using System;

namespace iWishApp.Models
{
    public class Affirmations
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
        public AffirmationsCategory Category { get; set; }

        public int CategoryId { get; set; }

        public int Id { get; set; }

        public ICollection<HashTag>? HashTag { get; set; }

        public Affirmations(string title, string description, string picture) 
        {
            Title = title;
            Description = description;
            Picture = picture;
            Tags = new List<HashTag>();
        }
        public Affirmations() 
        {

        }
        public override string ToString()
        {
            return Title;
        }

        public override bool Equals(object obj) 
        {
            return obj is Affirmations @Affirmations
                && Id == @Affirmations.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
