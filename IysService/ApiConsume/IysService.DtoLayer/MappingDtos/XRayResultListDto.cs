using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DtoLayer.MappingDtos
{
    public class XRayResultListDto
    {
        public int XRayResultID { get; set; }
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public int XRayNormalImageID { get; set; }
        public string? XRayNormalImageUrl { get; set; }
        public int XRayFinishedImageID { get; set; }
        public string? XRayFinishedImageUrl { get; set; }
        public string? XRayTitle { get; set; }
        public string? XRayDescription { get; set; }
        public bool XRayImageIsFinished { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public int CreatedUserID { get; set; }
    }
}
