using System.Collections.Generic;
using EFCoreBase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreBase.ModelSimple
{
    public class ApplicationDbContextSimple : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlite("Data Source=/Users/alextorrenti/Projects/VAERSA/Dia1/Dia1/databaseSimple.db")
          .EnableSensitiveDataLogging(true)
          .UseLoggerFactory(MyLoggerFactory);

        public static readonly ILoggerFactory MyLoggerFactory
           = LoggerFactory.Create(builder =>
           {
               builder
                   .AddFilter((category, level) =>
                       category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information)
                   .AddConsole();
           });

        /*
        protected override void OnModelCreating(Modelbuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .HasMany(c => c.Participantes)
                .WithOne(e => e.Curso);
        }
        */

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

    


