using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RPSLSGame.Data.EntityConfigurations;


public class AuditEntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : AuditEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired(false);
    }
}
