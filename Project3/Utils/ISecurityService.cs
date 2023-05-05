using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project3.Entity.Dto;
using Project3.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Project3.Utils
{
    public interface ISecurityService
    {
        Task<string> CreateToken(User user, string role);
        Task<PasswordDto> CreatePasswordHash(string password);
        Task<bool> VerifyPasswordHash(string password, byte[] passwordHash, byte[] paswordSalt);
    }

    public class SecurityService : ISecurityService
    {
        IConfiguration _configuration;
        public SecurityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<PasswordDto> CreatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var passwordSalt = hmac.Key;
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return new PasswordDto(passwordHash, passwordSalt);
            }
        }

        public async Task<string> CreateToken(User user, string role)
        {
            string id = user.Id.ToString();
            List<Claim> claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.NameIdentifier, id),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<bool> VerifyPasswordHash(string password, byte[] passwordHash, byte[] paswordSalt)
        {
            using (var hmac = new HMACSHA512(paswordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
