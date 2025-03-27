using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uc_13_Caua_WebSite.Models;

namespace Uc_13_Caua_WebSite.Data
{
    public class Uc_13_Caua_WebSiteContext : DbContext
    {
        public Uc_13_Caua_WebSiteContext (DbContextOptions<Uc_13_Caua_WebSiteContext> options)
            : base(options)
        {

        }
       
        public DbSet<Uc_13_Caua_WebSite.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<Uc_13_Caua_WebSite.Models.Fornecedor> Fornecedor { get; set; } = default!;
        public DbSet<Uc_13_Caua_WebSite.Models.Produto> Produto { get; set; } = default!;
        public DbSet<Uc_13_Caua_WebSite.Models.Pedido> Pedido { get; set; } = default!;
        public DbSet<Uc_13_Caua_WebSite.Models.Item_Pedido> Item_Pedido { get; set; } = default!;
    }
}
