using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator? _mediator => HttpContext.RequestServices.GetService<IMediator>() ?? throw new InvalidOperationException("IMediator can not be resolved.");
    }
}