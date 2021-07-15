using GlobalTourAPI.Services.Features.CustomerFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace GlobalTourAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var test = await Mediator.Send(new GetAllCustomerQuery());
            return Ok(await Mediator.Send(new GetAllCustomerQuery()));
        }
    }
}
