using System;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Common.Interfaces;

public interface ISubscriptionRepository
{
  void AddSubcription(Subscription subscription);
}
