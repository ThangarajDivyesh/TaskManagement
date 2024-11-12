using TaskManagerAPI.Models;

namespace TaskManagerAPI.DTO
{
    public class UserloginRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

     
    }
}
