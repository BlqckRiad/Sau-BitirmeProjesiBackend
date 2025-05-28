using IysService.BusinessLayer.Abstract;
using IysService.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IysService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        [HttpGet]
        public IActionResult GetUserActivitys(int userId)
        {
            var activitys = _activityService.TGetList().Where(x => x.ActivityUserID == userId);
            return Ok(activitys);
        }
    }
}
