using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dna.NetCore.Core.DAL.EFCore.Configuration.Temporary.EFTeam
{
    // cref: https://github.com/aspnet/EntityFramework/issues/2805#issue-99973931
    /// <summary>
    ///     temporary pattern provided by EF Core team
    ///     until implemented in EF Core
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
