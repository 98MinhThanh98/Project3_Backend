using System.ComponentModel.DataAnnotations;

namespace Project3.Entity.Dto
{
    public class RegisterReq
    {
        [Required]
        public string Username { get; set; }        
        [Required]
        public string Password { get; set; }
        public string? role { get; set; }

    }
}
