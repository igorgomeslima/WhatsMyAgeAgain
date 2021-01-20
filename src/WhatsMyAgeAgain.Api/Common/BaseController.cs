using Microsoft.AspNetCore.Mvc;

namespace WhatsMyAgeAgain.Api.Common
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }

        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return base.BadRequest(Envelope.Error(errorMessage));
        }
    }
}
