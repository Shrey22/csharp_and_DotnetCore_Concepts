using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySampleApp.Models;

namespace MySampleApp.Data
{
    public class MySampleAppContext : DbContext
    {
        public MySampleAppContext (DbContextOptions<MySampleAppContext> options)
            : base(options)
        {
        }

        public DbSet<MySampleApp.Models.Product> Product { get; set; } = default!;
    }
}
