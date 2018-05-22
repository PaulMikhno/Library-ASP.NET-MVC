using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Library.Entities.Models;
using Library.DAL;


namespace Library.DAL.Migrations
{
 
    internal sealed class Configuration : DbMigrationsConfiguration<LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LibraryContext context)
        {
            //Book s1 = new Book { Id = 1, Name = "Book1", Author = "Author1", YearOfPublishing = "1998" };
            //Book s2 = new Book { Id = 2, Name = "Book2", Author = "Author2", YearOfPublishing = "1998" };
            //Book s3 = new Book { Id = 3, Name = "Book3", Author = "Author3", YearOfPublishing = "1998" };
            //Book s4 = new Book { Id = 4, Name = "Book4", Author = "Author4", YearOfPublishing = "1998" };

            //context.Books.Add(s1);
            //context.Books.Add(s2);
            //context.Books.Add(s3);
            //context.Books.Add(s4);

            //PublicHouse c1 = new PublicHouse
            //{
            //    Id = 1,
            //    Name = "MegaPrinter",
            //    Address = "Address",
            //    Books = new List<Book> { s1, s2 }

            //};
            //PublicHouse c2 = new PublicHouse
            //{
            //    Id = 1,
            //    Name = "AllPrint",
            //    Address = "Address",
            //    Books = new List<Book> { s1, s2 }

            //};

            //context.PublicHouses.Add(c1);
            //context.PublicHouses.Add(c2);

        }
    }
}
