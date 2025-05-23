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
    class BaseAuditableEntityConfigurations<Tkey,TEntity> : BaseEntityConfigurations<Tkey, TEntity>
        where Tkey:IEquatable<Tkey>
        where TEntity:BaseAuditableEntity<Tkey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.CreatedBy).HasColumnType("varchar(50)");
            builder.Property(E => E.LastModifiedBy).HasColumnType("varchar(50)");
            builder.Property(E => E.CreatedOn).HasDefaultValueSql("GETUTCDate()");
            builder.Property(E => E.LastModifiedOn).HasComputedColumnSql("GETUTCDate()");
        }
    }
}
