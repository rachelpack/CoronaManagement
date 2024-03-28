using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalController : ControllerBase
    {
        protected Result JsonRes(Status status, string message = null, object data = null)
        {
            return new Result()
            {
                SaveStatus = status,
                Message = message,
                Data = data
            };
        }
      
    }
}
