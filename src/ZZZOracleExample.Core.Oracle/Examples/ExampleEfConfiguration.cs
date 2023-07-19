using ZZZOracleExample.Core.Examples.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZZZOracleExample.Core.Examples;

public class ExampleEfConfiguration : IEntityTypeConfiguration<Example>
{
    public void Configure(EntityTypeBuilder<Example> builder)
    {
        builder.ToTable("EXAMPLES");

        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(ExampleConstrains.NameMaxLength);
    }
}