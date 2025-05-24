using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.EntityLayer.Concrete
{
    public class UpdateXRayResultWithFinalyDto
    {
        public int XRayResultID { get; set; }
        public int XRayFinishedImageID { get; set; }
        public string? XRayFinishedImageUrl { get; set; }
        public string? XRayTitle { get; set; }
        public string? XRayDescription { get; set; }
        public bool XRayImageIsFinished { get; set; }
    }
}
