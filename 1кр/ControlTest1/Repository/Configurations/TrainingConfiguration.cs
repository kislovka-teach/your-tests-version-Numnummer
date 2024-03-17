using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Level)
            .IsRequired()
            .HasAnnotation("AnnotationName:MinimumValue", 1);

            builder.HasData(new Training()
            {
                Id = 1,
                Level = 1,
                Description="Hello this is description",
                Name="best training"
            });
        }
    }
}
