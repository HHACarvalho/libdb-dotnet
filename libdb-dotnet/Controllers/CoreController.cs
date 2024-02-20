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
                    return StatusCode(result.StatusCode, new { error = result.Error });
                }

                return StatusCode(result.StatusCode, result.Value);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}