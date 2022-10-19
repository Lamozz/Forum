using Forum.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Dal.EntityConfiguration
{
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Messages)
                .HasForeignKey(fk => fk.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Theme)
                .WithMany(x => x.Messages)
                .HasForeignKey(fk => fk.ThemeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
