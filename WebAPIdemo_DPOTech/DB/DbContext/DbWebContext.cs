using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebAPIdemo_DPOTech.Confiction;
using WebAPIdemo_DPOTech.DB.Models;

namespace WebAPIdemo_DPOTech.DB.DbWebContext;

public class DbWebContext:DbContext
{
    public DbWebContext(DbContextOptions<DbWebContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<News> Newses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);


        //modelBuilder.Entity<Category>(entity =>
        //{
        //    entity.ToTable("CATEGORY");
        //    entity.HasKey(c => c.CategoryId);

        //});
        //modelBuilder.Entity<News>(entity =>
        //{
        //    entity.ToTable("NEWS");
        //    entity.HasKey(p => p.NewsId);
        //    entity.HasOne(p => p.Category)
        //        .WithMany(p => p.News)
        //        .HasForeignKey(p => p.CategoryId)
        //        .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);
        //});

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new NewsConfiguration());
    }
}