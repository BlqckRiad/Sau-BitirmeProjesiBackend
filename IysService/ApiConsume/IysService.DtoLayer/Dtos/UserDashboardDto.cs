using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DtoLayer.Dtos
{
    public class UserDashboardDto
    {
        public int SumAppointments { get; set; }
        public int UpcomingAppointmentsCount { get; set; }
        public List<ActivityDto> Last5Activities { get; set; }
    }

}
