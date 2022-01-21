using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tweet_comment_engine.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { set; get; }
        [Required]
        public string UserName { set; get; }
        [Required]
        public string Name { set; get; }
        public string Bio { set; get; } 
        public virtual ICollection<Tweet> Tweets { set; get; } = new List<Tweet>();
    }
}
