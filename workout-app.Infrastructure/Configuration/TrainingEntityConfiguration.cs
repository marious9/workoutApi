using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using workout_app.Core.Domain;

namespace workout_app.Data.Configuration
{
    public class TrainingEntityConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            
            builder.HasKey(t => t.Id);
            builder.HasMany(t => t.Exercises)
                   .WithOne(t => t.Training);
        }
}
}
