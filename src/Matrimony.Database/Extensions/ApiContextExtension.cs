using Matrimony.Database.Entities.V1;
using Matrimony.Database.V1;
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
            // Default user
            var testUser = new AppUser
            {
                UserName = "test123",
                Email = "test@demo.com",
                PasswordHash = "Test+123456"
            };

            context.Users.Add(testUser);
            context.SaveChanges();
        }
    }
}
