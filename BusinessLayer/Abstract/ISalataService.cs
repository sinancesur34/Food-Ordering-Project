using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISalataService
    {
        List<Salata> GetList();
        void SalataAdd(Salata Salata);
        void SalataDelete(Salata Salata);
        void SalataUpdate(Salata Salata);
        Salata GetByID(int id);
    }
}
