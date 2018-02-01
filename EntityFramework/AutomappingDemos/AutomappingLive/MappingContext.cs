namespace AutomappingLive
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using AutomappingLive.Models;

    public class MappingContext : DbContext
    {
        public MappingContext()
            : base("name=MappingContext")
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}