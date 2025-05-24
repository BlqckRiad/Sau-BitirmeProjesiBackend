using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.EntityLayer.Concrete
{
    public class Contact : BaseEntity
    {
        [Key]
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string ContactUserEmail { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur.")]
        public string ContactUserName { get; set; }

        public string? Subject { get; set; }

        public string? Message { get; set; }

        public bool IsChecked {get; set;} = false;
    }
}
