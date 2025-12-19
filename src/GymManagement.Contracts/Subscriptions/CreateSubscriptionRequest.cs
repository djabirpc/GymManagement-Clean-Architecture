using GymManagement.Contracts.Subscriptions;

namespace GymManagement.Contracts.Subcriptions;

public record class CreateSubscriptionRequest(
  SubscriptionType SubscriptionType,
  Guid AdminId);
