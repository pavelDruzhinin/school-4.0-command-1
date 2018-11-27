using RecSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecSystem.Data.Mapping
{
    public class RatingMap : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x=>x.ID);
            builder.HasOne(x => x.Item).WithMany(x => x.Ratings).HasForeignKey(x=>x.ItemID);
            builder.HasOne(x => x.Customer).WithMany(x => x.Ratings).HasForeignKey(x => x.CustomerId);
        }
    }
}
