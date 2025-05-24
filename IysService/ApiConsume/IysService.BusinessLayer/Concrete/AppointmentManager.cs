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

    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentDal _dal;

        public AppointmentManager(IAppointmentDal dal)
        {
            _dal = dal;
        }
        public void TAdd(Appointment entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Appointment id)
        {
            _dal.Delete(id);
        }

        public Appointment TGetByid(int id)
        {
            return _dal.GetByid(id);
        }

        public List<Appointment> TGetList()
        {
            return _dal.GetList();
        }

        public void TUpdate(Appointment entity)
        {
            _dal.Update(entity);
        }
    }
}
