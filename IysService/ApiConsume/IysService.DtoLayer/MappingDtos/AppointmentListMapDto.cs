using IysService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DtoLayer.MappingDtos
{
    public class AppointmentListMapDto
    {
        public int AppointmentID { get; set; }

        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDateStart { get; set; }
        public DateTime AppointmentDateFinish { get; set; }

        public string AppointmentTitle { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserID { get; set; }
    }
}
