using RecSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecSystem.Data.Mapping
{
    public class ItemGenresMap : IEntityTypeConfiguration<ItemGenres>
    {

        public void Configure(EntityTypeBuilder<ItemGenres> builder)
        {
            builder.HasKey(x=>x.ID);
            builder.HasOne(x => x.Item).WithMany(x => x.ItemGenres).HasForeignKey(x=>x.ItemID);
            builder.HasOne(x => x.Genre).WithMany(x => x.ItemGenres).HasForeignKey(x=>x.GenreID);
        }

    }
}
