using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITatliService
    {
        List<Tatli> GetList();
        void TatliAdd(Tatli Tatli);
        void TatliDelete(Tatli Tatli);
        void TatliUpdate(Tatli Tatli);
        Tatli GetByID(int id);
    }
}
