using System;

namespace GymManagement.Application.Services;

public class SubscriptionsService : ISubscriptionsService
{
  public Guid CreateSubcription(string subscriptionType, Guid adminId)
  {
    return Guid.NewGuid();
  }
}
