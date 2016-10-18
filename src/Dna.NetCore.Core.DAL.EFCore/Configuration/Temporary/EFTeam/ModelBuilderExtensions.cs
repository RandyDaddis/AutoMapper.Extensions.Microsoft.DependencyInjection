using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dna.NetCore.Core.DAL.EFCore.Configuration.Temporary.EFTeam
{
    // cref: https://github.com/aspnet/EntityFramework/issues/2805#issue-99973931
    /// <summary>
    ///     temporary pattern provided by EF Core team
    ///     until implemented in EF Core
    /// </summary>
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration)
            where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}
