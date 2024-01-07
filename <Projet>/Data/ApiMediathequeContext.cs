using Microsoft.EntityFrameworkCore;

public class ApiMediathequeContext : DbContext
{
    public DbSet<Document> Documents { get; set; } = null!;
    public DbSet<Utilisateur> Utilisateurs { get; set; } = null!;
    public DbSet<Emprunt> Emprunts { get; set; } = null!;

    public string DbPath { get; private set; }


    public ApiMediathequeContext()
    {
        // Path to SQLite database file
        DbPath = "ApiMediatheque.db";
    }

    // The following configures EF to create a SQLite database file locally
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        //options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurations du modèle ici, par exemple :

        // Ignore emprunteur dans la configuration du modèle
        modelBuilder.Entity<Document>().Ignore(d => d.EmprunteurIds);
        modelBuilder.Entity<Utilisateur>().Ignore(d => d.Documents);

        // ... autres configurations du modèle

        base.OnModelCreating(modelBuilder);
    }

}

