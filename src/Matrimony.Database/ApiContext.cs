using System;
using System.Collections.Generic;
using System.Text;
using Matrimony.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Matrimony.Database
{
    public class ApiContext : IdentityDbContext<AppUser>
    {
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioType> PortfolioTypes { get; set; }
        public object Type { get; internal set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
        }
    }
}
