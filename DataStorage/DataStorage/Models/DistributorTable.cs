using System.ComponentModel.DataAnnotations;

namespace DataStorage.Models
{
    public class DistributorTable
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public int DistributorID { get; set; }
        [Display(Name = "Месец")]
        public Month? Month { get; set; }
        public int YearInputID { get; set; }
        [Display(Name = "Реализација")]
        public int Realization { get; set; }
        [Display(Name = "Цена на чинење на производ")]
        public int PriceOfCostOfProduct { get; set; }
        [Display(Name = "Гратиси")]
        public int Gratis { get; set; }
        [Display(Name = "Кусок")]
        public int Shortage { get; set; }
        [Display(Name = "Магацин")]
        public int Storage { get; set; }
        [Display(Name = "Истовар")]
        public int Unload { get; set; }
        [Display(Name = "Комерцијалист")]
        public int Commercialist { get; set; }
        [Display(Name = "Бруто Плата")]
        public int BrutoPay { get; set; }
        [Display(Name = "Бруто Процент")]
        public int BrutoPercent { get; set; }
        [Display(Name = "Нето Плата")]
        public int NetoPay { get; set; }
        [Display(Name = "Нето Процент")]
        public int NetoPercent { get; set; }
        [Display(Name = "Гориво")]
        public int Fuel { get; set; }
        [Display(Name = "Сервис")]
        public int Service { get; set; }
        [Display(Name = "Потрошен материјал")]
        public int Consumables { get; set; }
        [Display(Name = "Регистрација/Осигурување")]
        public int RegistrationInsurance { get; set; }
        [Display(Name = "Други Трошоци На име")]
        public int OtherExpenses { get; set; }



        public virtual Distributor Distributor { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual YearInput YearInput { get; set; }

    }
    public enum Month
    {
        Јануари = 1, Февруари, Март, Април, Мај, Јуни, Јули, Август, Септевмри, Октомври, Ноември, Декември
    }

}