using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataStorage.Models
{
    public class YearInput
    {
        public int ID { get; set; }
        [Display(Name = "Година")]
        public string Year { get; set; }

        public virtual ICollection<DistributorTable> DistributorTables { get; set; }
    }
}