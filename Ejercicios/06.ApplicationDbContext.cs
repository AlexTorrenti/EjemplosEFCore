using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreBase.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Data Seeding (el ID es obligatorio)
            var categoria1 = new Categoria() { ID = 1, Nombre = "Desarrollo Web", Activa = true, FechaAlta = DateTime.Now };
            var categoria2 = new Categoria() { ID = 2, Nombre = "Desarrollo Móvil", Activa = true, FechaAlta = DateTime.Now };
            var categoria3 = new Categoria() { ID = 3, Nombre = "Microsoft", Activa = true, FechaAlta = DateTime.Now };
            var categoria4 = new Categoria() { ID = 4, Nombre = "Seguridad", Activa = true, FechaAlta = DateTime.Now };

            modelBuilder.Entity<Categoria>().HasData(new Categoria[] { categoria1, categoria2, categoria3, categoria4});

            // Filtro a nivel de modelo
            modelBuilder.Entity<Curso>().HasQueryFilter(c => c.Activo);

            modelBuilder.Entity<Usuario>().HasQueryFilter(u => u.EstaActivo);

            modelBuilder.Entity<Categoria>().HasQueryFilter(c => c.Activa);

            // Relación n a n
            modelBuilder.Entity<Matriculacion>()
          .HasKey(m => new { m.EstudianteID, m.CursoID });

            modelBuilder.Entity<Matriculacion>()
                .HasOne(m => m.Curso)
                .WithMany(c => c.Participantes)
                .HasForeignKey(m => m.CursoID);

            modelBuilder.Entity<Matriculacion>()
                .HasOne(m => m.Estudiante)
                .WithMany(e => e.Cursos)
                .HasForeignKey(m => m.EstudianteID);

            // Relación 1 a 1

            modelBuilder.Entity<Profesor>()
                .HasOne(u => u.Curso)
                .WithOne(c => c.Profesor)
                .HasForeignKey<Profesor>(u => u.CursoID);
            
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => 
        options.UseSqlite("Data Source=/Users/alextorrenti/Projects/VAERSA/Dia1/Dia1/database.db")
             .EnableSensitiveDataLogging(true)
            //.UseLazyLoadingProxies() -- Falta Añadir la dependencia
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

            
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matriculacion> Matriculaciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
