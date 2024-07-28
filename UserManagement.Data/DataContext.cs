using System;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Data;

public class DataContext : DbContext, IDataContext
{
    public DataContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase("UserManagement.Data.DataContext");

    protected override void OnModelCreating(ModelBuilder model)
        => model.Entity<User>().HasData(new[]
        {
            new User
            {
                Id = 1,
                Forename = "Peter",
                Surname = "Loew",
                Email = "ploew@example.com",
                IsActive = true,
                DateOfBirth = DateOnly.Parse("1962-07-07")
            },
            new User
            {
                Id = 2,
                Forename = "Benjamin Franklin",
                Surname = "Gates",
                Email = "bfgates@example.com",
                IsActive = true,
                DateOfBirth = DateOnly.Parse("1968-04-29")
            },
            new User
            {
                Id = 3,
                Forename = "Castor",
                Surname = "Troy",
                Email = "ctroy@example.com",
                IsActive = false,
                DateOfBirth = DateOnly.Parse("1969-06-13")
            },
            new User
            {
                Id = 4,
                Forename = "Memphis",
                Surname = "Raines",
                Email = "mraines@example.com",
                IsActive = true,
                DateOfBirth = DateOnly.Parse("1986-09-13")
            },
            new User
            {
                Id = 5,
                Forename = "Stanley",
                Surname = "Goodspeed",
                Email = "sgodspeed@example.com",
                IsActive = true,
                DateOfBirth = DateOnly.Parse("1994-04-14")
            },
            new User
            {
                Id = 6,
                Forename = "H.I.",
                Surname = "McDunnough",
                Email = "himcdunnough@example.com",
                IsActive = true,
                DateOfBirth = DateOnly.Parse("1999-12-16")
            },
            new User
            {
                Id = 7,
                Forename = "Cameron",
                Surname = "Poe",
                Email = "cpoe@example.com",
                IsActive = false,
                DateOfBirth = DateOnly.Parse("2004-07-13")
            },
            new User
            {
                Id = 8,
                Forename = "Edward",
                Surname = "Malus",
                Email = "emalus@example.com",
                IsActive = false,
                DateOfBirth = DateOnly.Parse("2005-05-24")
            },
            new User
            {
                Id = 9,
                Forename = "Damon",
                Surname = "Macready",
                Email = "dmacready@example.com",
                IsActive = false,
                DateOfBirth = DateOnly.Parse("2006-06-28")
            },
            new User
            {
                Id = 10,
                Forename = "Johnny",
                Surname = "Blaze",
                Email = "jblaze@example.com",
                IsActive = true,
                DateOfBirth = DateOnly.Parse("2006-11-27")
            },
            new User
            {
                Id = 11,
                Forename = "Robin",
                Surname = "Feld",
                Email = "rfeld@example.com",
                IsActive = true,
                DateOfBirth = DateOnly.Parse("2017-01-06")
            },
        });

    public DbSet<User>? Users { get; set; }

    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        => base.Set<TEntity>();

    public void Create<TEntity>(TEntity entity) where TEntity : class
    {
        base.Add(entity);
        SaveChanges();
    }

    public new void Update<TEntity>(TEntity entity) where TEntity : class
    {
        base.Update(entity);
        SaveChanges();
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        base.Remove(entity);
        SaveChanges();
    }

    public IEnumerable Changes<TEntity>(TEntity entity) where TEntity : class
    {
        return base.Entry(entity).Properties.Where(p => p.IsModified).Select(p => p.Metadata.Name).ToList();
    }
}
