using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.InterFace;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Repository
{
    public class UserloginRepository :IUserloginRepository
    {
        private readonly TaskContext _context;

        public UserloginRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {           

            var data= await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return data.Entity;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var data = await _context.Users.SingleOrDefaultAsync(s => s.Email == email);
            return data;
        }

    }
}
