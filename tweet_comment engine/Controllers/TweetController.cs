using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tweet_comment_engine.Models;
using tweet_comment_engine.Repositories;

namespace tweet_comment_engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ITweetRepository _tweetRepository;

        public TweetController(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        [HttpGet("GetAllTweets")]
        public async Task<IEnumerable<Tweet>> GetAllTweets()
        {

            return await _tweetRepository.GetALLTweets();
        }
        /// <summary>
        ///  get user tweets with thier related comments
        /// </summary>
        /// <param name="user_id">
        /// id refer to the user 
        /// </param>
        /// <returns>
        /// a specific user tweets
        /// </returns>
        [HttpGet("GetTweets/{user_id}")]
        public async Task<ICollection<Tweet>> GetTweets(int user_id)
        {
            return await _tweetRepository.GetTweets(user_id);
        }
        /// <summary>
        /// add tweet
        /// </summary>
        /// <param name="tweet">
        /// a tweet object that carry the tweet info
        /// </param>
        /// <returns>
        /// the saved tweet object in the database
        /// </returns>
        [HttpPost("PostTweet")]
        public async Task<Tweet> PostTweet([FromBody] Tweet tweet)
        {

            var newTweet = await _tweetRepository.AddTweet(tweet);

            return newTweet;
        }
    }
}
