using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HansJhonnyAPI.Configuration
{
    public class EntityConfigurator<TEntity> where TEntity : class
    {
        private EntityTypeBuilder<TEntity> _entityTypeBuilder;

        public EntityConfigurator(EntityTypeBuilder<TEntity> entityTypeBuilder)
        {
            _entityTypeBuilder = entityTypeBuilder;
        }

        public EntityConfigurator<TEntity> Has(Action<EntityTypeBuilder<TEntity>> builder)
        {
            builder(_entityTypeBuilder);
            return this;
        }
    }
}
