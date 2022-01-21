using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tweet_comment_engine.Models
{
    public class Tweet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TweetId { set; get; }
        [ForeignKey("UserId")]
        public int UserId { set; get; }
        [MaxLength(140)]
        [Required]
        public string Content { set; get; }
        public virtual ICollection<Comment> Comments { set; get; } = new List<Comment>();

    }
}
