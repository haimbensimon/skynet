using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrasturture.Data
{
    public class StoreContext: DbContext
    {
        public DbSet<Product> Products {get;set;}
        public StoreContext(DbContextOptions<StoreContext> options): base(options)
        {
            
        }

    }
}