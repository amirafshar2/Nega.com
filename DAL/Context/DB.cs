using BE;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class DB : IdentityDbContext<User, UserRolee,int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=nega;Encrypt=True;user=sa; password=1; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<PortfolioCateory> portfolioCateories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<NewsLater> newsLaters { get; set; }
        public DbSet<OurContact> ourContacts { get; set; }
        public DbSet<Package> packages { get; set; }
        public DbSet<Portfolio> portfolios { get; set; }
        public DbSet<Services> services { get; set; }
        public DbSet<Success> successes { get; set; }
        public DbSet<Video> video { get; set; }
        public DbSet<CustomerComment> customerComments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Notification> notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reply>()
         .HasOne(r => r.ParentReply)
         .WithMany(r => r.Replies)
         .HasForeignKey(r => r.ParentReplyId)
         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.user)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.userid)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Blog)
                .WithMany(b => b.comments)
                .HasForeignKey(c => c.BlogId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }

}

