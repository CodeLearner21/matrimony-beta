using Matrimony.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrimony.Database.Extensions
{
    public static class ApiContextExtension
    {
        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
        public static void EnsureSeeded(this ApiContext context)
        {
            if (!context.Users.Any())
            {
                // Default user
                var testUser = new AppUser
                {
                    UserName = "test123",
                    Email = "test@test.com",
                    PasswordHash = "Test+123456"
                };

                context.Users.Add(testUser);
                context.SaveChanges();
            }

            if(!context.PortfolioTypes.Any())
            {
                List<PortfolioType> portfolioTypes = new List<PortfolioType>
                {
                    new PortfolioType { Name = "Self" },
                    new PortfolioType { Name = "Son" },
                    new PortfolioType { Name = "Doughter" },
                    new PortfolioType { Name = "Brother" },
                    new PortfolioType { Name = "Sister" },
                    new PortfolioType { Name = "Relative" },
                };

                context.PortfolioTypes.AddRange(portfolioTypes);
                context.SaveChanges();
            }
        }
    }
}
