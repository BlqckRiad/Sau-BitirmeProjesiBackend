using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DtoLayer.MappingDtos
{
    public class ContactListMapDto
    {
        public int ContactID { get; set; }
        public string ContactUserEmail { get; set; }
        public string ContactUserName { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public bool IsChecked { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
