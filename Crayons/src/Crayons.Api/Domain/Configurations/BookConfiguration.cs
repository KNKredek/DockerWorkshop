using Microsoft.EntityFrameworkCore;
using Crayons.Api.Domain.Models;

namespace Crayons.Api.Domain.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
        }
    }
}