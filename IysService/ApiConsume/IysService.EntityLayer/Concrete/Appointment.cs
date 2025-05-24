using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.EntityLayer.Concrete
{
    public class Appointment : BaseEntity
    {
        [Key]
        public int AppointmentID { get; set; }
        
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDateStart { get; set; }
        public DateTime AppointmentDateFinish { get; set; }

        public string AppointmentTitle { get; set; }
        public AppointmentStatus Status { get; set; }
    }
    public enum AppointmentStatus
    {
        Bekliyor,
        Onaylandı,
        Tamamlandı,
        İptalEdildi
    }

}
