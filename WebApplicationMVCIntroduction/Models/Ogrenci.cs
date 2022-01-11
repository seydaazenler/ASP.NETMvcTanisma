using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMVCIntroduction.Models
{
    public class Ogrenci: IEquatable<Ogrenci>
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public static List<Ogrenci> OgrenciListesi{ get; set; } = new List<Ogrenci>();
        public static List<Ogrenci> OgrenciyiGetir()
        {
            if (OgrenciListesi.Count ==0)
            {
                OgrenciListesi = new List<Ogrenci>()
                {
                    new Ogrenci(){Id=1,Ad="Betül",Soyad="Akşan",DogumTarihi=new DateTime(1992,11,14)},
                    new Ogrenci(){Id=2,Ad="Şeyda",Soyad="Zenler",DogumTarihi=new DateTime(1996,6,12)},
                    new Ogrenci(){Id=3,Ad="Gökhan",Soyad="Yıldız",DogumTarihi=new DateTime(1995,3,6)},
                    new Ogrenci(){Id=4,Ad="Zehra",Soyad="Zenler",DogumTarihi=new DateTime(2003,9,15)},
                };
            }
            return OgrenciListesi;
               
        
        }

        public bool Equals(Ogrenci other)
        {
            return Id == other.Id;
        }
    }
}