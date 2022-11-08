using Forum.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Forum.Dal.EntityConfiguration
{
    internal class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder
                .HasMany(x => x.Themes)
                .WithOne(x => x.Section)
                .HasForeignKey(fk => fk.SectionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
