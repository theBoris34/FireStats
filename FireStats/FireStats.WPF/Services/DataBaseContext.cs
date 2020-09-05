using FireStats.WPF.Models.Applicants;
using FireStats.WPF.Models.Base;
using FireStats.WPF.Models.Departments;
using System.Data.Entity;

namespace FireStats.WPF.Services
{
    class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DBConnectionString")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<Fire> Fires { get; set; }

        //public DbSet<Accident> Accidents { get; set; }

        //public DbSet<Applicant> Applicants { get; set; }

        //public DbSet<Injured> Injureds { get; set; }

        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Unit> Units { get; set; }


    }
}
