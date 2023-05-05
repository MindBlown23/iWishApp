using System;
using System.ComponentModel.DataAnnotations;

namespace iWishApp.Models
{
    public class GoogleProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
         public string Email { get; set; }
        public string Verified_Email { get; set; }
        public string MobilePhone { get; set; }   
        
        public string Locale { get; set; }
        
/*        public Users(string username, string password, string email) 
        { 
            UserName = username;
            Password = password;
            Email = email;
        }
        public Users()
        {

        }*/
    }
}
