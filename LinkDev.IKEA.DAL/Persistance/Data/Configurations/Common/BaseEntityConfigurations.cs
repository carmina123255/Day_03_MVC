using LinkDev.IKEA.DAL.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistance.Data.Configurations.Common
{
    class BaseEntityConfigurations<Tkey, TEntity> : IEntityTypeConfiguration<TEntity>
        where Tkey : IEquatable<Tkey>
        where TEntity : BaseEntity<Tkey>

    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
