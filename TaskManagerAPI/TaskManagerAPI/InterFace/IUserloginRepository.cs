using TaskManagerAPI.Models;

namespace TaskManagerAPI.InterFace
{
    public interface IUserloginRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUserByEmail(string email);
    }
}
