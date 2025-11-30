using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DtoLayer.Dtos
{
    public class LastDisResult
    {
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public int XRayNormalImageID { get; set; }
        public string? XRayNormalImageUrl { get; set; }
        public string? XRayTitle { get; set; }
        public string? XRayDescription { get; set; }
    }
}
