using IysService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DtoLayer.Dtos
{
    public class ChangeAppointmentDto
    {
        public int AppointmentID { get; set; }
        public int ChangerUserID { get; set; }
        public AppointmentStatus Status { get; set; }
       
    }
}
