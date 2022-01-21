using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tweet_comment_engine.Models;


namespace tweet_comment_engine.Repositories
{
  public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetComments();
        Task<Comment> AddComment(Comment comment);


    }
}
