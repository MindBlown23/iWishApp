using System;


namespace iWishApp.Models
{
    public class MotivationsCategory
    { 
        public int Id { get; set; } 
        public string Title { get; set; }
        public List<Motivations> Motivations { get; set; }  
        
       
        public MotivationsCategory(string title) 
        { 
            Title = title;
        }

        public MotivationsCategory() 
        { 
        }
    }
}
