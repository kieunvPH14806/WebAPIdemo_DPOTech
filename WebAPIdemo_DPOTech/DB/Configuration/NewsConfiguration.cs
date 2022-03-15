using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WebAPIdemo_DPOTech.DB.Models;

namespace WebAPIdemo_DPOTech.Confiction;

public class NewsConfiguration : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.ToTable("NEWS");
        builder.HasKey(p => p.NewsId);
        builder.HasOne(p => p.CategoryForView)
            .WithMany(p => p.News);
    }
}