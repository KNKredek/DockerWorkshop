using Microsoft.EntityFrameworkCore;
using Crayons.Api.Domain.Models;

namespace Crayons.Api.Domain.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
        }
    }
}