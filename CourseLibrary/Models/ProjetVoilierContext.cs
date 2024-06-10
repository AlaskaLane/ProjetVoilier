using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourseLibrary.Models;

public partial class ProjetVoilierContext : DbContext
{
    public DbSet<Course> Course { get; set; }
    public DbSet<Epreuve> Epreuves { get; set; }
    public DbSet<Penalite> Penalite { get; set; }
    public DbSet<Personne> Personnes { get; set; }
    public DbSet<TypePenalite> TypePenalite { get; set; }
    public DbSet<Voilier> Voilier { get; set; }
    public DbSet<VoilierEnCourse> VoilierEnCourse { get; set; }

    public ProjetVoilierContext()
    {
    }

    public ProjetVoilierContext(DbContextOptions<ProjetVoilierContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;Database=projet_voilier;Uid=root;Pwd=tardis;Port=3307;Allow User Variables=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Epreuve>()
            .HasOne(p => p.Course)
            .WithMany(b => b.Epreuves)
            .HasForeignKey(p => p.CourseId);

        modelBuilder.Entity<Penalite>()
            .HasKey(p => new { p.VoilierEnCourseId, p.Latitude, p.Longitude });
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
