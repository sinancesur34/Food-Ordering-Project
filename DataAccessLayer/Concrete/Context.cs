using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;


namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {

      

        public DbSet<Satis> Satiss { get; set; }
        public DbSet<Tatli> Tatlis { get; set; }
        public DbSet<Yemek> Yemeks { get; set; }
        public DbSet<Salata> Salatas { get; set; }
        public DbSet<Menu> Menus { get; set; }

    }
}
