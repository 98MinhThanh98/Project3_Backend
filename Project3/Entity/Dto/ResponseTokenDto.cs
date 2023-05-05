using System.ComponentModel.DataAnnotations;

namespace Project3.Entity.Dto
{
    public class ResponseTokenDto
    {
        public ResponseTokenDto()
        {
        }

        public ResponseTokenDto(string accessToken, DateTime iat, DateTime expired)
        {
            AccessToken = accessToken;
            Iat = iat;
            Expired = expired;
        }

        public string? AccessToken { get; set; }
        public DateTime? Iat { get; set; }
        public DateTime? Expired { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
