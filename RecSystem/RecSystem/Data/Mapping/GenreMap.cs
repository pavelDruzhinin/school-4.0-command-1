using RecSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecSystem.Data.Mapping
{
    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x=>x.ID);
            builder.HasMany(x=>x.ItemGenres);
        }
    }
}
