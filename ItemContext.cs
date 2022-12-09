using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekz_codeFirst
{
    internal class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<Entry> Entries { get; set; }

    }
}
