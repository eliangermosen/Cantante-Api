using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CantanteApi.Models;

namespace CantanteApi.Data
{
    public class CantanteApiContext : DbContext
    {
        public CantanteApiContext (DbContextOptions<CantanteApiContext> options)
            : base(options)
        {
        }

        public DbSet<CantanteApi.Models.Cantante> Cantante { get; set; }
    }
}
