using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Entities.Context
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)

        {
        }
  public DbSet<Productos> Productos { get; set; }
  public DbSet<Distribuidores> Distribuidores { get; set; }
    }
}
