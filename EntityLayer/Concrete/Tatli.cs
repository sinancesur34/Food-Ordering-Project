using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
   public class Tatli
    {
        [Key]
        public int TatliID { get; set; }
        public string TatliName { get; set; }
        public int Fiyat { get; set; }
        public ICollection <Satis> Satiss { get; set; }
    }
}
