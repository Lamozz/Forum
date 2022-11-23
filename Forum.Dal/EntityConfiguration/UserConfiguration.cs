using Forum.Common.Dtos.User;
using Forum.Domain;
using Forum.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Dal.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(x => x.Avatar)
                .WithOne(x => x.User)
                .HasForeignKey<Avatar>(a => a.Id);
        }
    }
}
