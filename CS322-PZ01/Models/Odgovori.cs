using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CS322_PZ01.Models
{
    [Table("Odgovor")]
    public class Odgovori
    {

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OdgovorID { get; set; }
        public string UserName { get; set; }
        public string Odgovor { get; set; }

        [Display(Name = "Komentar")]
        public int KomentarID { get; set; }

        [ForeignKey("KomentarID")]
        public virtual Komentari komentar { get; set; }

    }
}