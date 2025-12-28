using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subcriptions;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using DomainSubscriptionType = GymManagement.Domain.Subscriptions.SubscriptionType;

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
      if(!DomainSubscriptionType.TryFromName(
        request.SubscriptionType.ToString(),
        out var subscriptionType
      ))
      {
        return Problem(
          statusCode : StatusCodes.Status400BadRequest,
          detail: "Invalid subscription Type"
        );
      }
      var command = new CreateSubscriptionCommand(
          subscriptionType,
          request.AdminId);
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
          Enum.Parse<SubscriptionType>(subscription.SubscriptionType.Name))),
        error => Problem()
      );
    }
  }
}
