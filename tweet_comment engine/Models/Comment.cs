using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tweet_comment_engine.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { set; get; }
        //it carry the comment or tweet id user is replying on  
        public int RefId { set; get; }
        [Required]
        public string Content { set; get; }
        //a mark to shows if user  is replying on a tweet or a comment 
        [Required]
        public bool  TweetReply { set; get; }
        public virtual ICollection<Comment> Comments { set; get; } = new List<Comment>();
    }
}
