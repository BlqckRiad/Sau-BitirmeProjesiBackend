using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DtoLayer.Dtos
{
    public class AddXRayResultWithOutFinalyDto
    {
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public int XRayNormalImageID { get; set; }
        public string? XRayNormalImageUrl { get; set; }
    }
}
