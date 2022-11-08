using Forum.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Dal.EntityConfiguration
{
    internal class ThemeConfiguration : IEntityTypeConfiguration<Theme>
    {
        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            builder
                .HasMany(x => x.Messages)
                .WithOne(x => x.Theme)
                .HasForeignKey(fk => fk.ThemeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.Themes)
                .HasForeignKey(fk => fk.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
