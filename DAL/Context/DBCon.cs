using BE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
    public class DBCon : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=nega;Encrypt=True;user=sa; password=1; TrustServerCertificate=True;");
        }
        DbSet<User> users {  get; set; }
        DbSet<Blog> blogs {  get; set; }
        DbSet<About> abouts { get; set; }
        DbSet<Category> categories { get; set; }
        DbSet<Comment> comments { get; set; }
        DbSet<Contact> contacts { get; set; }
        DbSet<NewsLater> newsLaters { get; set; }
        DbSet<OurContact> ourContacts { get; set; }
        DbSet<Package> packages { get; set; }
        DbSet<Portfolio> portfolios { get; set; }
        DbSet<Services> services { get; set; }
        DbSet<Success> successes { get; set; }
        DbSet<Video>    video { get; set; } 


    }
}
