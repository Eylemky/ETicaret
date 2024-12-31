using ETicaretEntity.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretEntity.Seeds
{
    public class SiteSettinSeed:IEntityTypeConfiguration<SiteSetting>
    {
        public void Configure(EntityTypeBuilder<SiteSetting> builder)
        {
            builder.HasData(
                new SiteSetting
                {
                    SiteSettingId=1,
                    Key = "SiteTitle",
                    Value = "My E-Store Website"
                },
                new SiteSetting
                {
                    SiteSettingId=2,
                    Key = "SiteDescription",
                    Value = "The best e-store platform to meet all your needs!"
                },
                new SiteSetting
                {
                    SiteSettingId=3,
                    Key = "ContactEmail",
                    Value = "support@myestore.com"
                },
                new SiteSetting
                {
                    SiteSettingId=4,
                    Key = "ContactPhone",
                    Value = "0 850 444 8 444"
                },
                new SiteSetting
                {
                    SiteSettingId=5,
                    Key = "DefaultCurrency",
                    Value = "USD"
                }
                );

        }
    }
}
