using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataStorage.Models
{
    public class Distributor
    {
        public int ID { get; set; }
        [Display(Name = "Име и Презиме")]
        [Required(ErrorMessage = "Внесете Име и Презиме")]
        public string NameSurname { get; set; }
        [Display(Name = "Град")]
        [Required(ErrorMessage = "Изберете Град")]
        public City? City { get; set; }

        public virtual ICollection<DistributorTable> DistributorTables { get; set; }
    }

    public enum City
    {
        Скопје, Битола, Куманово, Прилеп, Тетово, Велес, Штип, Охрид,
        Гостивар, Струмица, Кавадарци, Кочани, Кичево, Струга, Радовиш,
        Гевгелија, Дебар, [Display(Name = "Крива Паланка")] Крива_Паланка,
        [Display(Name = "Свети Николе")] Свети_Николе, Неготино, Делчево, Виница,
        Ресен, Пробиштип, Берово, Кратово, Богданци, Крушево, [Display(Name = "Македонска Каменица")] Македонска_Каменица,
        Валандово, [Display(Name = "Македонски Брод")] Македонски_Брод, [Display(Name = "Демир Капија")] Демир_Капија, Пехчево,
        [Display(Name = "Демир Хисар")] Демир_Хисар
    }

}