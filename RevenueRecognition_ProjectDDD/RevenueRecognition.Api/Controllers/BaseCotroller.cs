using Microsoft.AspNetCore.Mvc;

namespace RevenueRecognition.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseCotroller : ControllerBase
{
    protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
    {
        return result is null ? NotFound() : Ok(result);
    }
}