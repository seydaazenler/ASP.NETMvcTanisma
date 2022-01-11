using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationMVCIntroduction.Models
{
    public class Ogrenci: IEquatable<Ogrenci>
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Öğrenci adı boş geçilemez!")]
        [StringLength(maximumLength:25, MinimumLength =2, ErrorMessage ="Adınız 2 ile 20 karakter aralığında olamlıdır..")]
        
        public string Ad { get; set; }
        [Required(ErrorMessage = "Öğrenci soyadı boş geçilemez!")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Soyadınız 2 ile 20 karakter aralığında olamlıdır..")]
        public string Soyad { get; set; }
        public DateTime? DogumTarihi { get; set; }
        //soru işareti NULLABLE yapmaya izin verir
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