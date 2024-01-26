using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISatisService
    {
        List<Satis> GetList();
        void SatisAdd(Satis Satis);
        void SatisDelete(Satis Satis);
        void SatisUpdate(Satis Satis);
        Satis GetByID(int id);
    }
}
