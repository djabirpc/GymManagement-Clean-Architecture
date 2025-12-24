using System;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Common.Interfaces;

public interface ISubscriptionRepository
{
  Task AddSubcriptionAsync(Subscription subscription);
  Task<Subscription?> GetByIdAsync(Guid Id);
}
