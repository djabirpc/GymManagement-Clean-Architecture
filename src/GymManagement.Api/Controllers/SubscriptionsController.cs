using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subcriptions;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
  {
    private readonly IMediator _mediator;
    public SubscriptionsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
      var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(),request.AdminId);
      var createSubscriptionResult = await _mediator.Send(command);

      return createSubscriptionResult.MatchFirst(
          subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
          error => Problem()
      );

      // if (createSubscriptionResult.IsError)
      // {
      //   return Problem();
      // }

      // var response = new SubscriptionResponse(createSubscriptionResult.Value, request.SubscriptionType);
      // return Ok(response);
    }

    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscription(Guid subscriptionId)
    {
      var query = new GetSubscriptionQuery(subscriptionId);
      var getSubscriptionResult = await _mediator.Send(query);
      
      return getSubscriptionResult.MatchFirst(
        subscription => Ok(new SubscriptionResponse(
          subscription.Id,
          Enum.Parse<SubscriptionType>(subscription.SubscriptionType))),
        error => Problem()
      );
    }
  }
}
