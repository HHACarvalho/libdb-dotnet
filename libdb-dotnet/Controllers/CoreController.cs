using libdb_dotnet.Core;
using Microsoft.AspNetCore.Mvc;

namespace libdb_dotnet.Controllers
{
    public class CoreController : Controller
    {
        protected async Task<IActionResult> HandleServiceCall(Func<Task<Result>> serviceMethod)
        {
            try
            {
                var result = await serviceMethod();
                if (!result.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { error = result.Error });
                }

                return StatusCode(StatusCodes.Status200OK, result.Value);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}