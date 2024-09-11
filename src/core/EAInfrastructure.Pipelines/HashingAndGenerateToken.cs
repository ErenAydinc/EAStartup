using Core.EADomain.Domains;
using Isopoh.Cryptography.Argon2;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace EAInfrastructure
{
    public class HashingAndGenerateToken
    {
        private readonly IConfiguration _configuration;

        public HashingAndGenerateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user, List<string> operationClaims, string password)
        {
            if (user == null)
            {
                return "Email is wrong";
            }
            else if (Argon2.Verify(user.Password, password) == false)
            {
                return "Password is wrong";
            }
            else
            {
                // Create JWT token handler and get secret key
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

                var userFullName = user.FirstName + " " + user.LastName;
                // Prepare list of user claims
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,userFullName),
                new Claim("IsActive",Convert.ToString(user.IsActive.Value))
            };

                foreach (var role in operationClaims)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                // Create token descriptor
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    IssuedAt = DateTime.UtcNow,
                    Issuer = _configuration["JWT:Issuer"],
                    Audience = _configuration["JWT:Audience"],
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                //Create token and set it to use
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                return user.Token;
            }
        }

        public string HashPassword(string password)
        {
            var hashedPassword = Argon2.Hash(password);
            return hashedPassword;
        }
    }
}
