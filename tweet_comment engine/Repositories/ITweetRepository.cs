using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tweet_comment_engine.Models;


namespace tweet_comment_engine.Repositories
{
  public interface ITweetRepository
    {
       
        Task<IEnumerable<Tweet>> GetALLTweets();
        Task<ICollection<Tweet>> GetTweets(int user_id);
        Task<Tweet> AddTweet(Tweet tweet);
    }
}
