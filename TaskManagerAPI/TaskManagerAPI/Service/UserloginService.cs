using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagerAPI.DTO;
using TaskManagerAPI.InterFace;
using TaskManagerAPI.Models;
using TaskManagerAPI.Repository;

namespace TaskManagerAPI.Service
{
    public class UserloginService : IUserloginService
    {
        private readonly IUserloginRepository _repository;
        private readonly IConfiguration _configuration;

        public UserloginService(IUserloginRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<string> Register(UserloginRequest request)
        {
            var req = new User
            {
                Name = request.Name,
                Email = request.Email,
                Role = request.Role,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),

            };

            var user = await _repository.AddUser(req);
            //var token = CreateToken(user);
            var token = "sample";
            return token;

        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _repository.GetUserByEmail(email);
            if (user == null)
            
                {
                    throw new Exception("user illai");
                }
            if(!BCrypt.Net.BCrypt.Verify(password,user.PasswordHash))
            {
                throw new Exception("thawarana ulleedu");
            }

            return CreateToken(user);
        }


        private string CreateToken(User user)
        {
            var claimList = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.Name),
                new Claim("Email", user.Email),
                new Claim("Role", user.Role.ToString())
            };

            // Ensure the key is at least 32 bytes long
            var keyString = _configuration["Jwt:Key"];

            // Make sure it's at least 32 bytes long (256 bits)
            var keyBytes = Encoding.ASCII.GetBytes(keyString);
            if (keyBytes.Length < 32)
            {
                var paddingLength = 32 - keyBytes.Length;
                keyBytes = keyBytes.Concat(new byte[paddingLength]).ToArray(); // Pad the key to 32 bytes if it's too short
            }

            var key = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims: claimList,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
