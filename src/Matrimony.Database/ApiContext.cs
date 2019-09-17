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
        public ApiContext(DbContextOptions options) : base(options)
        {
        }
    }
}
