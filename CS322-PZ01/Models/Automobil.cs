using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CS322_PZ01.Models
{
    [Table("Automobil")]
    public class Automobil
    {

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AutoID { get; set; }

        [Required]
        [Display(Name = "Naziv auta")]
        public string AutoNaziv { get; set; }

    }
}