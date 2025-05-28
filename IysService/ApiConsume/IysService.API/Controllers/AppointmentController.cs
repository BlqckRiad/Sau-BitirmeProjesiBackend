using AutoMapper;
using IysService.BusinessLayer.Abstract;
using IysService.DtoLayer.Dtos;
using IysService.DtoLayer.GeneralDtos;
using IysService.DtoLayer.MappingDtos;
using IysService.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IysService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;
        private readonly IActivityService _activityService;
        public AppointmentController(IAppointmentService appointmentService , IMapper mapper, IActivityService activityService)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
            _activityService = activityService;
        }
        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            var appointments = _appointmentService.TGetList().Where(x => x.IsDeleted == false);
            var appointmentMappeds = _mapper.Map<List<AppointmentListMapDto>>(appointments);

            return Ok(appointmentMappeds);
        }
        [HttpGet]
        public IActionResult GetAppointmentWithID(int id)
        {
            var appointments = _appointmentService.TGetByid(id);
            var appointmentMappeds = _mapper.Map<AppointmentListMapDto>(appointments);
            return Ok(appointmentMappeds);
        }
        [HttpPost]
        public IActionResult AddAppointment(AddAppointmentDto model)
        {
            var newAppointment = new Appointment
            {
                UserID = model.UserID,
                DoctorID = model.DoctorID,
                AppointmentDateFinish = model.AppointmentDateFinish,
                AppointmentDateStart = model.AppointmentDateStart,
                AppointmentTitle = model.AppointmentTitle,
                Status = AppointmentStatus.Bekliyor,
                CreatedDate = DateTime.Now,
                CreatedUserID = model.UserID,
            };
            _appointmentService.TAdd(newAppointment);

            var activity = new Activity
            {
                ActivityDesc = "Yeni randevu oluşturuldu.",
                ActivityUserID = model.UserID,
                ActivityType = ActivityType.Ekleme,
                ActivityDate = DateTime.Now,
            };
            _activityService.TAdd(activity);
            return Ok();
        }
        [HttpPost]
        public IActionResult DeleteAppointment (DeleteDto model)
        {
            var appointment = _appointmentService.TGetByid(model.DeletedItemID);
            if(appointment == null)
            {
                return NotFound("Randevu Bulunamadı");
            }
            appointment.DeletedDate = DateTime.Now;
            appointment.DeletedUserID = model.DeletedUserID;
            appointment.IsDeleted = true;
            appointment.Status = AppointmentStatus.İptalEdildi;
            _appointmentService.TUpdate(appointment);
            var activity = new Activity
            {
                ActivityDesc = "Randevu Silindi",
                ActivityUserID = model.DeletedUserID,
                ActivityType = ActivityType.Silme,
                ActivityDate = DateTime.Now,
            };
            _activityService.TAdd(activity);
            return Ok();
        }
        [HttpPost]
        public IActionResult ChangeAppointmentStatus(ChangeAppointmentDto model)
        {
            var appointment = _appointmentService.TGetByid(model.AppointmentID);
            if (appointment == null)
            {
                return NotFound("Randevu Bulunamadı");
            }
            appointment.UpdatedDate = DateTime.Now;
            appointment.UpdatedUserID = model.ChangerUserID;
            appointment.Status = model.Status;
            _appointmentService.TUpdate(appointment);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllUserAppointments(int userId)
        {
            var appointments = _appointmentService.TGetList().Where(x => x.IsDeleted == false && x.UserID == userId);
            var appointmentMappeds = _mapper.Map<List<AppointmentListMapDto>>(appointments);

            return Ok(appointmentMappeds);
        }
        [HttpGet]
        public IActionResult GetAllDoctorAppointments(int doctorId)
        {
            var appointments = _appointmentService.TGetList().Where(x => x.IsDeleted == false && x.DoctorID == doctorId);
            var appointmentMappeds = _mapper.Map<List<AppointmentListMapDto>>(appointments);

            return Ok(appointmentMappeds);
        }
        [HttpPost]
        public IActionResult UpdateAppointmentDate(UpdateAppointmentDateDto model)
        {
            var appointment = _appointmentService.TGetByid(model.AppointmentID);
            if (appointment == null)
            {
                return NotFound("Randevu Bulunamadı");
            }
            appointment.AppointmentDateStart = model.AppointmentDateStart;
            appointment.AppointmentDateFinish = model.AppointmentDateFinish;
            _appointmentService.TUpdate(appointment);
            return Ok();
        }
    }
}
