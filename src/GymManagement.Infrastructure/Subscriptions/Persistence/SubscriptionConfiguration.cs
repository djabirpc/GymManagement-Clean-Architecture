using System;
using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
  public void Configure(EntityTypeBuilder<Subscription> builder)
  {
    builder.HasKey(s => s.Id);

    builder.Property(s => s.Id)
      .ValueGeneratedNever(); // Generate the ID from Application and not DB, The Guid is generated from the application.
  
    builder.Property("_adminId")
      .HasColumnName("AdminId");

    builder.Property(s => s.SubscriptionType)
      .HasConversion(
        subscriptionType => subscriptionType.Value,
        value => SubscriptionType.FromValue(value)
      );

    // in case u wanna save the Name in Database and return the Value
    // builder.Property(s => s.SubscriptionType)
    //   .HasConversion(
    //     subscriptionType => subscriptionType.Name,
    //     value => SubscriptionType.FromName(value, false)
    //   );
  }
}
 