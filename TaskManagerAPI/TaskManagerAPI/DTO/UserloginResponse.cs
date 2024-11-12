namespace TaskManagerAPI.DTO
{
    public class UserloginResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Phone { get; set; }
    }
}
