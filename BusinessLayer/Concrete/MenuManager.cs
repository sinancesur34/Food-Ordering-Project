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
    public class MenuManager:IMenuService
    {
        IMenuDal _MenuDal;



        public MenuManager(IMenuDal MenuDal)
        {
            _MenuDal = MenuDal;
        }


        public void MenuAdd(Menu Menu)
        {
            _MenuDal.Insert(Menu);
        }

        public List<Menu> GetList()
        {
            return _MenuDal.List();
        
        }

        public void MenuDelete(Menu Menu)
        {
           _MenuDal.Delete(Menu);
        }

        public void MenuUpdate(Menu Menu)
        {
           _MenuDal.Update(Menu);
        }

        public Menu GetByID(int id)
        {
            return _MenuDal.Get(x => x.MenuID == id);
        }


        //ctrl+k+d   satırları düzenlemeye yarıyor

    }
}
