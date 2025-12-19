using System;

namespace GymManagement.Application.Services;

public interface ISubscriptionsService
{
  Guid CreateSubcription(string subscriptionType, Guid adminId);
}
