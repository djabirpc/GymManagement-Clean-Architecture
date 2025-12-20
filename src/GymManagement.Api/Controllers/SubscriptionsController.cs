using GymManagement.Application.Commands.CreateSubscription;
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
      var subcsriptionId = await _mediator.Send(command);
      var response = new SubscriptionResponse(subcsriptionId,request.SubscriptionType);
      return Ok(response);
    }
  }
}
