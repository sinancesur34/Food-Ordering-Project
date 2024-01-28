using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace EntityLayer.Concrete
{
    public class Satis
    {
        [Key]
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }
        public int TatliID { get; set; }

        public int TatliAdet { get; set; }
        public int YemekID { get; set; }

        public int YemekAdet { get; set; }
        public int SalataID { get; set; }

        public int SalataAdet { get; set; }
        public int MenuID { get; set; }
        public int MenuAdet { get; set; }
        public int Toplam { get; set; }

        public virtual Tatli Tatli { get; set; }
        public virtual Salata Salata { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Yemek Yemek { get; set; }



    }
}
