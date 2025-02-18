using InternetForum.DAL.DbExtentions;
using InternetForum.DAL.DomainModels;
using InternetForum.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetForum.DAL
{
    public class ForumDbContext : DbContext, IForumDb
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }
        public DbSet<Interest> UserInterests { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SetUpDataBase();
            builder.SeedDataForumDb();
            base.OnModelCreating(builder);
        }
    }
}
