using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Yemek
    {
        [Key]
        public int YemekID { get; set; }
        public string YemekName { get; set; }
        public int Fiyat { get; set; }
        public ICollection<Satis> Satiss { get; set; }
    }
}
