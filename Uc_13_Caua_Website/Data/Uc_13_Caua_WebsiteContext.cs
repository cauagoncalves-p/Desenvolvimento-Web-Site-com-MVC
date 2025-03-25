using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uc_13_Caua_Website.Models;

namespace Uc_13_Caua_Website.Data
{
    public class Uc_13_Caua_WebsiteContext : DbContext
    {
        public Uc_13_Caua_WebsiteContext (DbContextOptions<Uc_13_Caua_WebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<Uc_13_Caua_Website.Models.Fornecedor> Fornecedor { get; set; } = default!;
    }
}
