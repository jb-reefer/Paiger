using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Pager.Models
{
    public interface IPagerContext
    {
        DbSet<Genre> Genres { get; set; }

        DbSet<Article> Articles { get; set; }

        DbSet<Publisher> Publishers { get; set; }
    }

    public class PagerContext : DbContext, IPagerContext
    {
        IConfigurationRoot _config;

        public PagerContext(IConfigurationRoot config)
        {
            _config = config;
        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_config.GetValue<string>("DbConnectionString"));
        }

    }
}