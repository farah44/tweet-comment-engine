using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tweet_comment_engine.Models;

namespace tweet_comment_engine
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options): base(options)
        {
           //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
