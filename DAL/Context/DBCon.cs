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
        DbSet<About> abouts { get; set; }

    }
}
