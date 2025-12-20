using MediatR;

namespace GymManagement.Application.Commands.CreateSubscription;

public record class CreateSubscriptionCommand(string V, Guid adminId) : IRequest<Guid>
{

}
