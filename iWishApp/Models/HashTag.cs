using System;
using System.ComponentModel.DataAnnotations;

namespace iWishApp.Models
{
    public class HashTag
    {
        [Required(ErrorMessage = "Type is Required")]
        [StringLength(50, MinimumLength = 3,ErrorMessage = "Type Must be between 3 and 50 characters" )]
        public string Name { get; set; }
        public int Id { get; set; }

        public ICollection<Affirmations> Affirmations { get; set; }
        public HashTag(string name) 
        { 
            Name = name;
        }
        public HashTag()
        {

        }
    }
}
