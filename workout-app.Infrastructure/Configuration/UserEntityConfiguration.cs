using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using workout_app.Core.Domain;

namespace workout_app.Data.Configuration
{
    public class UserEntityConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasMany(x => x.RefreshTokens)
                .WithOne(x => x.User);
            builder
                .HasMany(x => x.Sessions)
                .WithOne(x => x.User);
            builder
                .Property(x => x.Password)
                .HasMaxLength(500);
            builder
                .Property(x => x.Username)
                .HasMaxLength(25)
                .IsRequired();
            builder
                .Property(x => x.FirstName)
                .HasMaxLength(50);
            builder
                .Property(x => x.LastName)
                .HasMaxLength(50);
        }
    }
}