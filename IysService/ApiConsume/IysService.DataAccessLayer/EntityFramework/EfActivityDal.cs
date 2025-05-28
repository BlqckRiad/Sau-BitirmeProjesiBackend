using IysService.DataAccessLayer.Abstract;
using IysService.DataAccessLayer.Concrete;
using IysService.DataAccessLayer.Repository;
using IysService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DataAccessLayer.EntityFramework
{
    
    public class EfActivityDal : GenericRepository<Activity>, IActivityDal
    {
        public EfActivityDal(Context context) : base(context)
        {

        }
    }
}
