using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBookStoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicBookStoreProject.Data
{
    public class ComicBookStoreProjectContext : DbContext
    {
        public ComicBookStoreProjectContext(DbContextOptions<ComicBookStoreProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Dimension> Dimension { get; set; }
        public DbSet<Comicbook> Comicbook { get; set; }
    }
}
