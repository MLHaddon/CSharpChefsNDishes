using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Context
{
    public class MyContext : DbContext
    {
        // Construct MyContext w/ DbContextOptions and a base (options) class
        public MyContext (DbContextOptions options) : base(options) { }
        public DbSet<Chef> Chefs {get; set;}
        public DbSet<Dish> Dishes {get; set;}
    }
}