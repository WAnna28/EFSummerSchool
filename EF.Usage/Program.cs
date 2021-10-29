using EF.Dal.EfStructures;
using EF.Dal.Repos;
using EF.Models.Entities;
using System;

namespace EF.Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            var carRepo = new CarRepo(new ApplicationDbContextFactory().CreateDbContext(null));

            carRepo.Add(new() { MakeId = 1, Color = "Black", PetName = "Zippy", IsDrivable = false });
            carRepo.Add(new() { MakeId = 2, Color = "Rust", PetName = "Rusty", IsDrivable = false });
            carRepo.Add(new() { MakeId = 3, Color = "Black", PetName = "Mel", IsDrivable = false });
            carRepo.Add(new() { MakeId = 4, Color = "Yellow", PetName = "Clunker", IsDrivable = false });
            carRepo.Add(new() { MakeId = 5, Color = "Black", PetName = "Bimmer", IsDrivable = false });
            carRepo.Add(new() { MakeId = 6, Color = "Black", PetName = "Pete", IsDrivable = false });

            Console.WriteLine("\n\n\n\nGetAllIgnoreQueryFilters");
            var cars = carRepo.GetAllIgnoreQueryFilters();
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}