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
    public class SalataManager:ISalataService
    {
        ISalataDal _SalataDal;



        public SalataManager(ISalataDal SalataDal)
        {
            _SalataDal = SalataDal;
        }


        public void SalataAdd(Salata Salata)
        {
            _SalataDal.Insert(Salata);
        }

        public List<Salata> GetList()
        {
            return _SalataDal.List();
        
        }

        public void SalataDelete(Salata Salata)
        {
           _SalataDal.Delete(Salata);
        }

        public void SalataUpdate(Salata Salata)
        {
           _SalataDal.Update(Salata);
        }

        public Salata GetByID(int id)
        {
            return _SalataDal.Get(x => x.SalataID == id);
        }


        //ctrl+k+d   satırları düzenlemeye yarıyor

    }
}
