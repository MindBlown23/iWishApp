using System;


namespace iWishApp.Models
{
    public class UserProfile
    { 
        public int Id { get; set; } 
        public string? UserName { get; set; }
        public string? Password { get; set; }    
        public string? Email { get; set; }
        public UserProfile(string username, string password, string email) 
        { 
            UserName = username;
            Password = password;
            Email = email;
        }

        private UserProfile() 
        { 
        }
    }
}
