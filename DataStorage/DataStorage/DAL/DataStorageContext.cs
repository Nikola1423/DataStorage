using DataStorage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DataStorage.DAL 
{
    public class DataStorageContext : DbContext
    {
        public DataStorageContext() : base("DataStorageContext")
        {

        }

        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<DistributorTable> DistributorTables { get; set; }
        public DbSet<YearInput> YearInputs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}