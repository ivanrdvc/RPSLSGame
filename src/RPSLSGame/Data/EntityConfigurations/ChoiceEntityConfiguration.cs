using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPSLSGame.Domain;

namespace RPSLSGame.Data.EntityConfigurations;

public class ChoiceEntityConfiguration : AuditEntityConfiguration<Choice>
{
    public override  void Configure(EntityTypeBuilder<Choice> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(256);
    }
}
