using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Library.Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Magazine> Magazines { get; set; }
    public DbSet<Brochure> Brochures { get; set; }
    public DbSet<PublicHouse> PublicHouses { get; set; }

    public LibraryContext(string connectionString)
       : base(connectionString)
    {
    }
    public LibraryContext()
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasMany(c => c.PublicHouses)
            .WithMany(s => s.Books)
            .Map(t => t.MapLeftKey("PublicHouse_Id")
            .MapRightKey("Book_Id ")
            .ToTable("PublicHouseBooks"));
    }


}