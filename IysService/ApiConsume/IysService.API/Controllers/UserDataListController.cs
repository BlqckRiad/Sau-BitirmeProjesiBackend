using IysService.BusinessLayer.Abstract;
using IysService.DtoLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IysService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserDataListController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IAppointmentService _appointmentService;

        public UserDataListController(IActivityService activityService, IAppointmentService appointmentService)
        {
            _activityService = activityService;
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult Get(int userID)
        {
            var sumAppointments = _appointmentService.TGetList()
                .Where(x => !x.IsDeleted
                            && x.UserID == userID
                            && x.CreatedDate > DateTime.Now)
                .Count();

            var upcomingAppointmentsCount = _appointmentService.TGetList()
                .Where(x => !x.IsDeleted
                            && x.UserID == userID
                            && x.CreatedDate > DateTime.Now
                            && x.CreatedDate <= DateTime.Now.AddDays(3))
                .Count();

            var userLast5Activities = _activityService.TGetList()
                .Where(x => x.ActivityUserID == userID)
                .OrderByDescending(x => x.ActivityDate)
                .Take(5)
                .Select(x => new ActivityDto
                {
                    ActivityDesc = x.ActivityDesc,
                    ActivityDate = x.ActivityDate,
                    ActivityType = x.ActivityType.ToString()
                })
                .ToList();

            var result = new UserDashboardDto
            {
                SumAppointments = sumAppointments,
                UpcomingAppointmentsCount = upcomingAppointmentsCount,
                Last5Activities = userLast5Activities
            };

            return Ok(result);
        }

    }
}
