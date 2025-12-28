using System;
using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
  private readonly ISubscriptionRepository _subscriptionRepository;
  private readonly IUnitOfWork _unitOfWork;

  public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
  {
    _subscriptionRepository = subscriptionRepository;
    _unitOfWork = unitOfWork;
  }

  public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
  {
    var subscription = new Subscription(
      subscriptionType : request.SubscriptionType,
      adminId : request.adminId
    );

     await _subscriptionRepository.AddSubcriptionAsync(subscription);

     await _unitOfWork.CommitChangesAsync();

    return subscription;
  }
}
