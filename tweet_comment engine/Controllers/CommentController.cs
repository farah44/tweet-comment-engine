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
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [HttpGet("GetComments")]
        public async Task<IEnumerable<Comment>> GetComments()
        {
            return await _commentRepository.GetComments();
        }
        /// <summary>
        /// Add comment on a tweet or on other comment
        /// </summary>
        /// <param name="comment">
        /// a comment object the hold the comments info
        /// </param>
        /// <returns>
        /// the saved comment object in the database
        /// </returns>
        [HttpPost("PostComment")]
        public async Task<Comment> PostComment([FromBody] Comment comment)
        {

            var newComment = await _commentRepository.AddComment(comment);

            return newComment;

        }
    }
}
