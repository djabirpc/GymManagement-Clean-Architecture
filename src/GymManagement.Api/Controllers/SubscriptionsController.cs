using GymManagement.Application.Services;
using GymManagement.Contracts.Subcriptions;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
  {

    private readonly ISubscriptionsService _subscriptionService;

    public SubscriptionsController(ISubscriptionsService subscriptionService)
    {
      _subscriptionService = subscriptionService;
    }

    [HttpPost]
    public IActionResult CreateSubscription(CreateSubscriptionRequest request)
    {
      var subcsriptionId = _subscriptionService.CreateSubcription(request.SubscriptionType.ToString(),request.AdminId);
      var response = new SubscriptionResponse(subcsriptionId,request.SubscriptionType);
      return Ok(response);
    }
  }
}
