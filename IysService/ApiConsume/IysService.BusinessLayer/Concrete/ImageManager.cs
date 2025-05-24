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
    
    public class ImageManager : IImageService
    {
        private readonly IImageDal _dal;

        public ImageManager(IImageDal dal)
        {
            _dal = dal;
        }
        public void TAdd(Image entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Image id)
        {
            _dal.Delete(id);
        }

        public Image TGetByid(int id)
        {
            return _dal.GetByid(id);
        }

        public List<Image> TGetList()
        {
            return _dal.GetList();
        }

        public void TUpdate(Image entity)
        {
            _dal.Update(entity);
        }
    }
}
