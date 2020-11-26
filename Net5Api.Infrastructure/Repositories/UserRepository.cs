using Microsoft.EntityFrameworkCore;
using Net5Api.Core.Entities;
using Net5Api.Core.Interfaces;
using Net5Api.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly Net5ApiContext _context;

        public UserRepository(Net5ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {

            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetUser(int id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            return user;
        }
    }
}
