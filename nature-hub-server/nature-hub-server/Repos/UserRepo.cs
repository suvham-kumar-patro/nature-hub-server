using Microsoft.EntityFrameworkCore;
using nature_hub_server.Data;
using nature_hub_server.Models;

namespace nature_hub_server.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly NatureHubDbContext _context;
        public UserRepo(NatureHubDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            // Check if the user already exists in the database based on a unique field like Email or Username
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UName == user.UName); // You can also check based on other fields, like Username

            if (existingUser != null)
            {
                // If user exists, throw an exception or handle accordingly
                throw new Exception("User already exists.");
            }

            // If user doesn't exist, add the new user
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteByid(int id)
        {

            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
