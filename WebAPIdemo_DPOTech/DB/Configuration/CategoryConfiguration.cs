using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPIdemo_DPOTech.DB.Models;

namespace WebAPIdemo_DPOTech.Confiction;

public class CategoryConfiguration:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("CATEGORY");
        builder.HasKey(p => p.CategoryId);
       
    }
}