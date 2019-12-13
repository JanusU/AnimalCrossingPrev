using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalCrossing.Areas.Identity.Data
{
    public class AnimalCrossingIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public AnimalCrossingIdentityDbContext(DbContextOptions<AnimalCrossingIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
