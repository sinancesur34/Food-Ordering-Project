using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class YemekManager:IYemekService
    {
        IYemekDal _YemekDal;



        public YemekManager(IYemekDal YemekDal)
        {
            _YemekDal = YemekDal;
        }


        public void YemekAdd(Yemek Yemek)
        {
            _YemekDal.Insert(Yemek);
        }

        public List<Yemek> GetList()
        {
            return _YemekDal.List();
        
        }

        public void YemekDelete(Yemek Yemek)
        {
           _YemekDal.Delete(Yemek);
        }

        public void YemekUpdate(Yemek Yemek)
        {
           _YemekDal.Update(Yemek);
        }

        public Yemek GetByID(int id)
        {
            return _YemekDal.Get(x => x.YemekID == id);
        }


        //ctrl+k+d   satırları düzenlemeye yarıyor

    }
}
