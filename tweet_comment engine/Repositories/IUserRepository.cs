using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tweet_comment_engine.Models;


namespace tweet_comment_engine.Repositories
{
  public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> Create(User user);
    }
}
