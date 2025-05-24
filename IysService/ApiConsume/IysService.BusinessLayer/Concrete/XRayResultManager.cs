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
    
    public class XRayResultManager : IXRayResultService
    {
        private readonly IXRayResultDal _dal;

        public XRayResultManager(IXRayResultDal dal)
        {
            _dal = dal;
        }
        public void TAdd(XRayResult entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(XRayResult id)
        {
            _dal.Delete(id);
        }

        public XRayResult TGetByid(int id)
        {
            return _dal.GetByid(id);
        }

        public List<XRayResult> TGetList()
        {
            return _dal.GetList();
        }

        public void TUpdate(XRayResult entity)
        {
            _dal.Update(entity);
        }
    }
}
