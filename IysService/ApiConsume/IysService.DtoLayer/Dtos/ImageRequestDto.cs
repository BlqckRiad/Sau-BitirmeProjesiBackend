using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DtoLayer.Dtos
{
    public class ImageRequestDto
    {
        public int ImageID { get; set; }

        public string? ImageName { get; set; }

        public string? ImageUrl { get; set; }
    }
}
