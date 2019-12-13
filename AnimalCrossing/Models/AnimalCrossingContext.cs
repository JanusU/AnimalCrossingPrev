using Microsoft.EntityFrameworkCore;
using AnimalCrossing.Models;
using System;

namespace AnimalCrossing.Data
{
    public class AnimalCrossingContext : DbContext
    {
        public AnimalCrossingContext(Microsoft.EntityFrameworkCore.DbContextOptions<AnimalCrossingContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Species> Species { get; set; }

    }
}
