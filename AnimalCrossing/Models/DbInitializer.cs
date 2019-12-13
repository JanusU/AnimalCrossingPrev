using System;
using System.Linq;
using AnimalCrossing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalCrossing.Models
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AnimalCrossingContext(
                serviceProvider.GetRequiredService<
                    Microsoft.EntityFrameworkCore.DbContextOptions<AnimalCrossingContext>>()))
            {
                if (!context.Species.Any())
                {
                    var species = new Species[]
                 {
                new Species{Name="Curl", Description="American Curl"},
                new Species{Name="Bengal", Description="Bengalise Cat"},
                new Species{Name="Chartreux", Description="French Breed"}, 
                new Species{Name="Himalayan", Description="Himalayan Cat Breed"},
                new Species{Name="Persian", Description="Persian Cat Breed"},
                new Species{Name="Siberian", Description="Siberian Cat Breed"}
                 };
                    foreach (Species s in species)
                    {
                        context.Species.Add(s);
                    }
                    context.SaveChanges();
                }

                if (!context.Cats.Any())
                {
                    var speciesType = context.Species.ToList();

                    var cats = new Cat[] {
                        new Cat{Name="Findus", BirthDate=new DateTime(2019, 9, 23), Description="Fat and lazy", Gender=Gender.Female, SpeciesId=speciesType[0].SpeciesId},
                        new Cat{Name="Tigeren", BirthDate=new DateTime(2017, 12,25), Description="A Wild boy", Gender=Gender.Male, SpeciesId=speciesType[1].SpeciesId},
                        new Cat{Name="Makronen", BirthDate=new DateTime(2017, 5,7), Description="Always loves a treat", Gender=Gender.Male, SpeciesId=speciesType[2].SpeciesId},
                        new Cat{Name="Lama", BirthDate=new DateTime(2012, 4,10), Description="Always relaxed", Gender=Gender.Male, SpeciesId=speciesType[3].SpeciesId},
                        new Cat{Name="Darius", BirthDate=new DateTime(2015, 7,14), Description="Comes from a respectably dynasty", Gender=Gender.Male, SpeciesId=speciesType[4].SpeciesId},
                        new Cat{Name="Sevasto", BirthDate=new DateTime(2018, 9,9), Description="Loves the winter", Gender=Gender.Female, SpeciesId=speciesType[5].SpeciesId},
                        new Cat{Name="Sorte", BirthDate=new DateTime(2014, 12,17), Description="Loves the dark", Gender=Gender.Female, SpeciesId=speciesType[2].SpeciesId},
                        new Cat{Name="Nougat", BirthDate=new DateTime(2017, 3,19), Description="Very Playful", Gender=Gender.Female, SpeciesId=speciesType[0].SpeciesId}
                    };
                    foreach (Cat c in cats)
                    {
                        context.Cats.Add(c);

                        context.SaveChanges();
                    }
                }
            }


        }


    }
}