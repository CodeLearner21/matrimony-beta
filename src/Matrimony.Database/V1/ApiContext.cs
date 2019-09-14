using System;
using System.Collections.Generic;
using System.Text;
using Matrimony.Database.Entities.V1;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Matrimony.Database.V1
{
    public class ApiContext : IdentityDbContext<AppUser>
    {
        public ApiContext(DbContextOptions options) : base(options)
        {
        }
    }
}
