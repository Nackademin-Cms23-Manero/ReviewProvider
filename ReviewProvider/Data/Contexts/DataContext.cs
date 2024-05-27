using Microsoft.EntityFrameworkCore;
using ReviewProvider.Data.Entities;

namespace ReviewProvider.Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<UserReviewEntity> UserReviews { get; set; }
    public DbSet<RatingEntity> Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserReviewEntity>().HasKey(x => new
        {
            x.Email,
            x.ProductId
        });
    }
}
