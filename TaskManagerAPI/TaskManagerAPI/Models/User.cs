using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string? Phone { get; set; }
        public Role Role { get; set; }

        public Address? Address { get; set; }

        public List<TaskItem>? TaskItems { get; set; }
    }
}
