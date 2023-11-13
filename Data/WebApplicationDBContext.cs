using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplicationDBContext : DbContext
    {
        public WebApplicationDBContext (DbContextOptions<WebApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Cake> Cake { get; set; } = default!;
    }
}
