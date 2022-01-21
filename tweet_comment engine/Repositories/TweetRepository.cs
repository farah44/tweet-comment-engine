using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tweet_comment_engine.Models;

namespace tweet_comment_engine.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly Db _context;

        public TweetRepository(Db context)
        {
            _context = context;
        }
        public async Task<Tweet> AddTweet(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            await _context.SaveChangesAsync();
            return tweet;
        }
        public async Task<ICollection<Tweet>> GetTweets(int user_id)
        {
             var tweets = await _context.Tweets.Where(T=>T.UserId==user_id).ToListAsync();
            tweets.ForEach(t =>
                 t.Comments =
                 _context.Comments.Where(c => c.TweetReply && c.RefId == t.TweetId).ToList()
                );

            return tweets;
        }
        public async Task<IEnumerable<Tweet>> GetALLTweets()
        {
            return await _context.Tweets.ToListAsync();
        }
    }
}
