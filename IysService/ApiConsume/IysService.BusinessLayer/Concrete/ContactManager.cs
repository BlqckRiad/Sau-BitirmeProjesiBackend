using IysService.BusinessLayer.Abstract;
using IysService.DataAccessLayer.Abstract;
using IysService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _dal;

        public ContactManager(IContactDal dal)
        {
            _dal = dal;
        }
        public void TAdd(Contact entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Contact id)
        {
            _dal.Delete(id);
        }

        public Contact TGetByid(int id)
        {
            return _dal.GetByid(id);
        }

        public List<Contact> TGetList()
        {
            return _dal.GetList();
        }

        public void TUpdate(Contact entity)
        {
            _dal.Update(entity);
        }
    }
}
