using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SuperVideos.Domain.Entities;
using SuperVideos.SharedKernel.EntityConfiguration;
using System.Linq;

namespace SuperVideos.SharedKernel.Contexts
{
    public sealed class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new MovieEntityConfiguration());


            foreach (var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(t => t.GetProperties())
                        .Where(p => p.ClrType == typeof(string)))
            {
                _ = property.AsProperty().Builder.HasMaxLength(256, ConfigurationSource.Convention);
            }

            //modelBuilder.Model.GetEntityTypes().

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasColumnType("varchar"));

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasMaxLength(250));

            //modelBuilder.Properties<DateTime>()
            //  .Configure(p => p.HasColumnType("datetime2"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
