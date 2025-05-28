using IysService.BusinessLayer.Abstract;
using IysService.DataAccessLayer.Abstract;
using IysService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.BusinessLayer.Concrete
{
    public class ActivityManager : IActivityService
    {
        private readonly IActivityDal _dal;

        public ActivityManager(IActivityDal dal)
        {
            _dal = dal;
        }
        public void TAdd(Activity entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Activity id)
        {
            _dal.Delete(id);
        }

        public Activity TGetByid(int id)
        {
            return _dal.GetByid(id);
        }

        public List<Activity> TGetList()
        {
            return _dal.GetList();
        }

        public void TUpdate(Activity entity)
        {
            _dal.Update(entity);
        }
    }
}
