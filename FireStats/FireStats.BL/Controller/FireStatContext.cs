

using FireStats.BL.Model;
using System.Data.Entity;

namespace FireStats.BL.Controller
{
    class FireStatContext : DbContext
    {
        public FireStatContext() : base("DBConnection") { }
        public DbSet<Emergency> Emergencies { get; set; }

        public DbSet<Fire> Fires { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserType> UserTypes { get; set; }


        public DbSet<WorkTime> WorkTimes { get; set; }


    }
}
