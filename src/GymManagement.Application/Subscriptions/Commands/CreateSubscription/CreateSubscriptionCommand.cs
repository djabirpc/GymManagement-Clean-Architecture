using ErrorOr;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public record class CreateSubscriptionCommand(
  SubscriptionType SubscriptionType, 
  Guid adminId) : IRequest<ErrorOr<Subscription>>
{

}
