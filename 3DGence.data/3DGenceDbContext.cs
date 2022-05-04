using _3DGence.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3DGence.data
{
    public class _3DGenceDbContext : DbContext
    {
        public _3DGenceDbContext(DbContextOptions<_3DGenceDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Printer> printers { get; set; }    
    }
}
