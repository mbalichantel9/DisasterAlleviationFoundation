using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisasterAlleviationFoundation.Models;
using Microsoft.EntityFrameworkCore;

namespace DisasterAlleviationFoundation.Data
{
    public class UsersContext : DbContext
    {

        public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
        {
        }

        public DbSet<GoodsDonations> GoodsDonations { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<MonetaryDonations> MonetaryDonations { get; set; }

        public DbSet<Disaster> Disasters { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
