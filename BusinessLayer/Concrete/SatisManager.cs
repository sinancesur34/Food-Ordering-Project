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
    public class SatisManager:ISatisService
    {
        ISatisDal _SatisDal;



        public SatisManager(ISatisDal SatisDal)
        {
            _SatisDal = SatisDal;
        }


        public void SatisAdd(Satis Satis)
        {
            _SatisDal.Insert(Satis);
        }

        public List<Satis> GetList()
        {
            return _SatisDal.List();
        
        }

        public void SatisDelete(Satis Satis)
        {
           _SatisDal.Delete(Satis);
        }

        public void SatisUpdate(Satis Satis)
        {
           _SatisDal.Update(Satis);
        }

        public Satis GetByID(int id)
        {
            return _SatisDal.Get(x => x.SatisID == id);
        }

        public object GetByID(object id)
        {
            throw new NotImplementedException();
        }


        //ctrl+k+d   satırları düzenlemeye yarıyor

    }
}
