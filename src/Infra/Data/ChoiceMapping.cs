using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data
{
    public class ChoiceMapping : IEntityTypeConfiguration<Choices>
    {

        public void Configure(EntityTypeBuilder<Choices> builder)
        {
            builder.Property(x => x.Choice).HasMaxLength(100).IsRequired();
            builder.HasOne(x => x.Question).WithMany(x => x.Choices).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
