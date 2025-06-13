using Microsoft.EntityFrameworkCore;
using RecordMania.Models;

namespace RecordMania.DAL;

public class RecordManiaDbContext : DbContext
{
    public RecordManiaDbContext(DbContextOptions<RecordManiaDbContext> options) : base(options)
    {
    }

    public DbSet<Language> Languages { get; set; }
    public DbSet<TaskS> Tasks { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Record> Records { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Record>()
            .HasOne(r => r.Language)
            .WithMany(l => l.Records)
            .HasForeignKey(r => r.LanguageId);

        modelBuilder.Entity<Record>()
            .HasOne(r => r.TaskS)
            .WithMany(t => t.Records)
            .HasForeignKey(r => r.TaskId);

        modelBuilder.Entity<Record>()
            .HasOne(r => r.Student)
            .WithMany(s => s.Records)
            .HasForeignKey(r => r.StudentId);
    }
}