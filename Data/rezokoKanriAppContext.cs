using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace rezokoKanriApp.Models
{
    public class rezokoKanriAppContext : DbContext
    {
        public rezokoKanriAppContext (DbContextOptions<rezokoKanriAppContext> options)
            : base(options)
        {
        }

        public DbSet<rezokoKanriApp.Models.StoredItemsClass> StoredItemsClass { get; set; }
    }
}
