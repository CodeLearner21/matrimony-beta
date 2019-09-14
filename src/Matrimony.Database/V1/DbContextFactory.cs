using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Database.V1
{
    public class DbContextFactory : DesignTimeDbContextFactoryBase<ApiContext>
    {
        protected override ApiContext CreateNewInstance(DbContextOptions<ApiContext> options)
        {
            return new ApiContext(options);
        }
    }
}
