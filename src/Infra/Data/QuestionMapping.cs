using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data
{
    public class QuestionMapping : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            builder.Property(x => x.Choices).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ImageUrl).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.ThumbUrl).HasMaxLength(1000).IsRequired();
        }
    }
}
