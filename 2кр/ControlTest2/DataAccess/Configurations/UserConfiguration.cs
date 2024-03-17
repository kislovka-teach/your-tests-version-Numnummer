using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Login);
            builder.Property(e => e.Password).IsRequired().HasAnnotation("Validation", "MinimumLength:6");

            var users = new List<User>()
            {
                new User()
                {
                    Login="log1",
                    Password="123",
                    Role="user"
                },
                new User()
                {
                    Login="log2",
                    Password="111",
                    Role="admin"
                }
            };
        }
    }
}
