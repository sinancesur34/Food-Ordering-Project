using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        public string MenuName { get; set; }

        public int Fiyat { get; set; }

        public ICollection<Satis> Satiss { get; set; }
    }
}
