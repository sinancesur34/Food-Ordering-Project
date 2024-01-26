using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IYemekService
    {
        List<Yemek> GetList();
        void YemekAdd(Yemek Yemek);
        void YemekDelete(Yemek Yemek);
        void YemekUpdate(Yemek Yemek);
        Yemek GetByID(int id);
    }
}
