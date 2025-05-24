using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DtoLayer.Dtos
{
    public class UpdateAppointmentDateDto
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDateStart { get; set; }
        public DateTime AppointmentDateFinish { get; set; }
        public int UserID { get; set; }
    }
}
