using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CS322_PZ01.Models
{
    [Table("Kategorija")]
    public class KategorijaModel
    {

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int KategorijaID { get; set; }

        [Required]
        [Display(Name = "Tip proizvoda")]
        public string KategorijaNaziv { get; set; }

    }
}