using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchmersalGlobalTask.Domain.Entities;

namespace SchmersalGlobalTask.Infrastructure
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");
            builder.HasKey(com => com.Id);
            builder.Property(com => com.Id).ValueGeneratedOnAdd();
        }
    }
}
