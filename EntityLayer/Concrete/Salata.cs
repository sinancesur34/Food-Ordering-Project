using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Salata
    {
        [Key]
        public int SalataID { get; set; }
        public string SalataName { get; set; }
        public int Fiyat { get; set; }
        public ICollection<Satis> Satiss { get; set; }
    }
}
