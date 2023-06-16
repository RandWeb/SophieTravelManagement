
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SophieTravelManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController
{
    protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result) => result is null ? NotFound() : Ok(result);
}