using TaskManagerAPI.DTO;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.InterFace
{
    public interface IUserloginService
    {
        Task<string> Register(UserloginRequest request);
        Task<string> Login(string email, string password);
       
    }
}
