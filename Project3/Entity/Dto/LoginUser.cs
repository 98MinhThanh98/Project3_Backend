using System.ComponentModel.DataAnnotations;

namespace Project3.Entity.Dto
{
    public class LoginUser
    {
        public LoginUser() { }
        public LoginUser(string _usernames, string _password)
        {
            Username = _usernames;
            Password = _password;
        }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
