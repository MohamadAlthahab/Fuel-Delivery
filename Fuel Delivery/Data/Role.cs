using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Fuel_Delivery.Data
{
    public class Role : IEntityTypeConfiguration<IdentityRole>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole
                 {
                     Name = "Admin",
                     NormalizedName = "Admin"
                 },
                 new IdentityRole
                 {
                     Name = "User",
                     NormalizedName = "User"
                 },
                 new IdentityRole
                 {
                     Name = "Driver",
                     NormalizedName = "Driver"
                 });
        }
    }

}
