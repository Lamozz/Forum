using Forum.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Dal.EntityConfiguration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasMany(x => x.Sections)
                .WithOne(x => x.Category)
                .HasForeignKey(fk => fk.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
