using System;


namespace iWishApp.Models
{
    public class AffirmationsCategory
    { 
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<Affirmations> affirmations { get; set; }  
        
       
        public AffirmationsCategory(string name) 
        { 
            Name = name;
        }

        public AffirmationsCategory() 
        { 
        }
    }
}
