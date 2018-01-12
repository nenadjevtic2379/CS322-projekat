using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CS322_PZ01.Models
{
    [Table("Narudzbina")]
    public class NarudzbinaModel
    {

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NarudzbinaID { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Model auta")]
        public string ProizvodiModel { get; set; }
        public string Cena { get; set; }

        [Display(Name = "Tip proizvoda")]
        public int KategorijaID { get; set; }

        [ForeignKey("KategorijaID")]
        public virtual KategorijaModel kategorija { get; set; }

        [Display(Name = "Za auto")]
        public int AutoID { get; set; }

        [ForeignKey("AutoID")]
        public virtual Automobil auto { get; set; }

        public DateTime Datum { get; set; }
        public int Status { get; set; }

    }
}