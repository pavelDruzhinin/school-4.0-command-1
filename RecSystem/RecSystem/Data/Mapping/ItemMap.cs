using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecSystem.Data.Mapping
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x=>x.ID);
            builder.HasMany(x => x.Ratings);
            builder.HasMany(x => x.ItemGenres);
        }
    }
}
