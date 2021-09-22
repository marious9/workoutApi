using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using workout_app.Core.Domain;

namespace workout_app.Data.Configuration
{
    public class UserTrainingConfiguration: IEntityTypeConfiguration<UserTraining>
    {
        public void Configure(EntityTypeBuilder<UserTraining> builder)
        {
            builder.HasKey(sc => new { sc.UserId, sc.TrainingId });
        }
    }
}