using Microsoft.EntityFrameworkCore;
using SuperVideos.Domain.Entities;
using SuperVideos.SharedKernel.EntityConfiguration;

namespace SuperVideos.SharedKernel.Contexts
{
    public sealed class MovieContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new MovieEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
