using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataStorage.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        [Display(Name = "Регистрација")]
        [Required(ErrorMessage = "Внесете Регистрација")]
        public string Registration { get; set; }
        [Display(Name = "Марка")]
        [Required(ErrorMessage = "Внесете Марка")]
        public string CarBrand { get; set; }
        [Display(Name = "Модел")]
        [Required(ErrorMessage = "Внесете модел")]
        public string CarModel { get; set; }

        public virtual ICollection<DistributorTable> DistributorTables { get; set; }

    }
}