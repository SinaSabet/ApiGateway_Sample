using ApiGateway.Domain.Common;
using ApiGateway.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Infrastructure.EntityConfiguration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            // تنظیم نام جدول مربوط به کلاس Service
            builder.ToTable("Services");

            // تنظیم کلید اصلی
            builder.HasKey(s => s.Id);

            // تنظیم محدودیت‌ها و ویژگی‌ها برای خصوصیات
            builder.Property(s => s.ServiceName).HasMaxLength(100).IsRequired();
            builder.Property(s => s.DownstreamPathTemplate).HasMaxLength(200).IsRequired();
            builder.Property(s => s.DownstreamScheme).HasMaxLength(20).IsRequired();
            builder.Property(s => s.UpstreamPathTemplate).HasMaxLength(200).IsRequired();
            builder.Property(s => s.Host).HasMaxLength(100).IsRequired();

            // تنظیم ارتباط بین Service و BaseEntity
            builder.HasBaseType<BaseEntity>();

        
        }
    }
}
