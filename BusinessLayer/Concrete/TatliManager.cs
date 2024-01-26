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
    public class TatliManager : ITatliService
    {
        ITatliDal _TatliDal;



        public TatliManager(ITatliDal TatliDal)
        {
            _TatliDal = TatliDal;
        }


        public void TatliAdd(Tatli Tatli)
        {
            _TatliDal.Insert(Tatli);
        }

        public List<Tatli> GetList()
        {
            return _TatliDal.List();

        }

        public void TatliDelete(Tatli Tatli)
        {
            _TatliDal.Delete(Tatli);
        }

        public void TatliUpdate(Tatli Tatli)
        {
            _TatliDal.Update(Tatli);
        }

        public Tatli GetByID(int id)
        {
            return _TatliDal.Get(x => x.TatliID == id);
        }


        //ctrl+k+d   satırları düzenlemeye yarıyor

    }
}
