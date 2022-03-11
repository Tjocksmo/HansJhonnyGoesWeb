using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HansJhonnyAPI.Configuration
{
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            Configure(new EntityConfigurator<TEntity>(builder));
        }

        protected abstract void Configure(EntityConfigurator<TEntity> configurator);
    }
}
