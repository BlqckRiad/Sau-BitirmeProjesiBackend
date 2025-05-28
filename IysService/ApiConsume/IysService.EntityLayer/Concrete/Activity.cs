using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.EntityLayer.Concrete
{
    public class Activity
    {
        [Key]
        public int ActivityID { get; set; }
        public int ActivityUserID { get; set; }
        public string ActivityDesc { get; set; }
        public DateTime ActivityDate { get; set; }
        public ActivityType ActivityType { get; set; }
    }
    public enum ActivityType
    {
        Ekleme,
        Silme,
        Güncelleme
    }
}
