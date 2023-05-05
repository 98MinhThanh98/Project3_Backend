using System.ComponentModel.DataAnnotations;

namespace Project3.Entity.Dto
{
    public class RegisterUser
    {
        public RegisterUser(string username, string name, string email, string password, DateTime dateOfBirth, int gender)
        {
            Username = username;
            Name = name;
            Email = email;
            Password = password;
            DateOfBirth = dateOfBirth;  
            Gender = gender;
        }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Gender { get; set; }

    }
}
