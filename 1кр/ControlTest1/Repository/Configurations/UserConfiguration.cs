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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Login);
            builder.Property(e => e.Login)
            .IsRequired()
            .HasAnnotation("AnnotationName:MinimumValue", 1);
            builder.Property(e => e.Password)
            .IsRequired()
            .HasAnnotation("AnnotationName:MinimumValue", 1);

            var users = new List<User>()
            {
                new User()
                {
                    Login="login1",
                    Password="password1",
                    Role="user"
                },
                new User()
                {
                    Login="admin",
                    Password="admin",
                    Role="couch"
                }
            };
            builder.HasData(users);
        }
    }
}
