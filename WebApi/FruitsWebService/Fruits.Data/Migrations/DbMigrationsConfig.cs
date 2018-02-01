using Fruits.Models;
using Fruits.Models.Enums;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Fruits.Data.Migrations
{
    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<FruitsContext>
    {
        private readonly List<Fruit> fruits = new List<Fruit>()
        {
            new Fruit() {  Name = "Apple", Color = Color.Green, Description = "Good for the health. Green.", Importance = Importance.Ten, Price = 112.3m },
            new Fruit() {  Name = "Banana", Color = Color.Red, Description = "Good for the health. Small.", Importance = Importance.Nine, Price = 124.3m },
            new Fruit() {  Name = "Pineapple", Color = Color.Purple, Description = "Good for the health. Big.", Importance = Importance.Eight, Price = 12.3m },
            new Fruit() {  Name = "Pear", Color = Color.Brown, Description = "Good for the health. Shiny.", Importance = Importance.Seven, Price = 12.34m },
            new Fruit() {  Name = "Mango", Color = Color.Yellow, Description = "Good for the health. Blue.", Importance = Importance.Six, Price = 1.3m },
            new Fruit() {  Name = "Apricot", Color = Color.Silver, Description = "Good for the health. Exotic.", Importance = Importance.Five, Price = 132.3m },
            new Fruit() {  Name = "Clementine", Color = Color.Green, Description = "Good for the health. Round.", Importance = Importance.Four, Price = 72.3m },
            new Fruit() {  Name = "Fig", Color = Color.Purple, Description = "Good for the health. Sweeeeeeet.", Importance = Importance.Three, Price = 52.3m },
            new Fruit() {  Name = "Kiwi", Color = Color.Green, Description = "Good for the health. Green.", Importance = Importance.Two, Price = 32.3m },
            new Fruit() {  Name = "Orange", Color = Color.Orange, Description = "Good for the health. Orange.", Importance = Importance.One, Price = 552.3m }
        };

        public DbMigrationsConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(FruitsContext context)
        {
            //  This method will be called after migrating to the latest version.
            if (!context.Fruits.Any())
            {
                foreach (var fruit in fruits)
                {
                    context.Fruits.Add(fruit);
                }

                context.SaveChanges();
            }
        }
    }
}
