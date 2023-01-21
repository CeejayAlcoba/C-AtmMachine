using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtmMachine.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        DbSet<User> Users
        {
            get;
            set;
        }
        DbSet<Money> Moneys
        {
            get;
            set;
        }
    }
}
