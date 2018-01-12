using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CS322_PZ01.Models
{
    [Table("Proizvodi")]
    public class ProizvodModel
    {

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProizvodiID { get; set; }

        [Display(Name = "Model")]
        public string ProizvodiModel { get; set; }

        [Display(Name = "Datum proizvodnje")]
        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatumProizvodnje { get; set; }

        [Display(Name = "Cena")]
        public string Cena { get; set; }
        
        [Display(Name = "Tip proizvoda")]
        public int KategorijaID { get; set; }

        [ForeignKey("KategorijaID")]
        public virtual KategorijaModel kategorija { get; set; }

        [Display(Name = "Za auto")]
        public int AutoID { get; set; }

        [ForeignKey("AutoID")]
        public virtual Automobil auto { get; set; }

        [Display(Name = "Slika")]
        public byte[] Slika { get; set; }
    }
}