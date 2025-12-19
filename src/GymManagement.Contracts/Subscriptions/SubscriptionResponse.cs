namespace GymManagement.Contracts.Subscriptions;

public record class SubscriptionResponse(
  Guid Id,
  SubscriptionType SubscriptionType);
