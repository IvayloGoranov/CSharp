using BookShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;

namespace BookShopSystem.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        private static Random random = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.ContextKey = "BookShopSystem.Data.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
        }
    }
}
