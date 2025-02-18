using InternetForum.DAL.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace InternetForum.DAL.DbExtentions
{
    public static class ForumDbSetUpDatabase
    {
        public static void SetUpDataBase(this ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique(true);

            builder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>()
                .HasMany(u => u.CommentReactions)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>()
               .HasMany(u => u.Posts)
               .WithOne(p => p.User)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>()
              .HasMany(u => u.PostReactions)
              .WithOne(p => p.User)
              .HasForeignKey(p => p.UserId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>()
                .HasMany(u => u.Interests)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Comment>()
                 .HasOne(c => c.Post)
                 .WithMany(p => p.Comments)
                 .HasForeignKey(c => c.PostId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PostReaction>()
                .HasOne(p => p.Post)
                .WithMany(p => p.Reactions)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CommentReaction>()
               .HasOne(c => c.Comment)
               .WithMany(c => c.Reactions)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CommentReaction>()
                .HasOne(c => c.User)
                .WithMany(u => u.CommentReactions)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Post>()
                .HasMany(p => p.Topics)
                .WithOne(t => t.Post)
                .HasForeignKey(t => t.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PostTopic>().HasKey(pt => new
            {
                pt.TopicId, pt.PostId
            });

            builder.Entity<UserInterest>().HasKey(ui => new
            {
                ui.UserId,
                ui.InterestId
            });
        }
    }
}
