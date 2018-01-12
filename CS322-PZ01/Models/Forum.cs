using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS322_PZ01.Models
{
    public class Forum
    {

        public IEnumerable<Odgovori> odgovori { get; set; }
        public IEnumerable<Komentari> komentari { get; set; }

    }
}