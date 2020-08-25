using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_FS
{
    class MyDBContext : DbContext
    {
        public MyDBContext() : base("DBConnectionString")
        {

        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<People> Peoples { get; set; }

        public DbSet<Home> Homes { get; set; }

    }
}
