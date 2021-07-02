using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperVideos.Domain.Entities;

namespace SuperVideos.SharedKernel.EntityConfiguration
{
    public sealed class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            _ = builder.ToTable("Movies")
                .HasKey(c => c.Id);

            _ = builder.OwnsOne(c => c.MovieDetail)
                .Property(c => c.BarCode)
                .HasColumnName("BarCode");

            _ = builder.OwnsOne(c => c.MovieDetail)
                .Property(c => c.Duration)
                .HasColumnName("Duration");

            _ = builder.OwnsOne(c => c.MovieDetail)
                .Property(c => c.Isbn)
                .HasColumnName("Isbn");

            _ = builder.OwnsOne(c => c.MovieDetail)
                .Property(c => c.Code)
                .HasColumnName("Code");

            _ = builder.OwnsOne(c => c.MovieDetail)
                .HasIndex(c => c.Code)
                .IsUnique();
                
        }
    }
}
