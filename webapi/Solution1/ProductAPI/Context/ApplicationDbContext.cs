using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.Models;

namespace ProductAPI.Context
{
    public class ApplicationDbContext: DbContext
    {

// Forma estandar de crear un constructor de clase
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options)
        {

        }

// Propiedad dbSet que se corresponde con una tabla en la BBDD
        public DbSet<Product> Product { get; set; }
    }
}
