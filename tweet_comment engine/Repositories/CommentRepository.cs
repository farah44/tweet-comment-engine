using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using tweet_comment_engine.Models;

namespace tweet_comment_engine.Repositories
{
    public class CommentRepository: ICommentRepository
    {
        private readonly Db _context;

        public CommentRepository(Db context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comment>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }
        /// <summary>
        /// add the comment object in the database 
        /// add the comment in the tweet list if comment is a reply on it 
        /// add the comment in the comment list in comment class if it was a replying on other comment  
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>
        /// the saved object
        /// </returns>
        public async Task<Comment> AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            if (comment.TweetReply)
            {
                var ref_tweet = _context.Tweets.FindAsync(comment.RefId);
                if(ref_tweet.Result.Comments==null)
                {
                    ref_tweet.Result.Comments = new List<Comment>();
                }
                ref_tweet.Result.Comments.Add(comment);
                _context.Tweets.Update(ref_tweet.Result);
                _context.Entry(ref_tweet.Result).State = EntityState.Modified;
            }
            else
            {
                var ref_comment = _context.Comments.FindAsync(comment.RefId);
                if (ref_comment.Result.Comments == null)
                {
                    ref_comment.Result.Comments = new List<Comment>();
                }
                ref_comment.Result.Comments.Add(comment);
                _context.Comments.Update(ref_comment.Result);
            }
            
            await _context.SaveChangesAsync();
            var ref_tweett = _context.Tweets.FindAsync(comment.RefId);
            return comment;
        }
    }
}
