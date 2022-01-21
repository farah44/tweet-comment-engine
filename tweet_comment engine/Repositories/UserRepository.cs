using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tweet_comment_engine.Models;


namespace tweet_comment_engine.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Db _context;

        public UserRepository(Db context)
        {
            _context= context;
        }
        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
