using Garbom.Core.Domain.Objects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garbom.Core.Infrastructure.Data.Mapping
{
    public static class EntityMapping<TEntity> where TEntity : Entity
    {
        public static void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Ignore(e => e.ValidationResult);
        }
    }
}
