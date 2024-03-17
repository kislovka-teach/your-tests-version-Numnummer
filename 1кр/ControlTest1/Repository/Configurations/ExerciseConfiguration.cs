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
    public class ExerciseConfiguration : IEntityTypeConfiguration<Excercise>
    {
        public void Configure(EntityTypeBuilder<Excercise> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.RestDuration)
            .IsRequired()
            .HasAnnotation("AnnotationName:MinimumValue", 1);
            builder.Property(e => e.Duration)
            .IsRequired()
            .HasAnnotation("AnnotationName:MinimumValue", 1);
            builder.Property(e => e.ApproachesCount)
            .IsRequired()
            .HasAnnotation("AnnotationName:MinimumValue", 1);
        }
    }
}
