using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using iWishApp.Models;
using Microsoft.AspNetCore.Authentication.Google;
namespace iWishApp.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{   

    public DbSet<Motivations> Motivations { get; set; } 
    public DbSet<MotivationsCategory> Categories { get; set; }
    public DbSet<HashTag> HashTag { get;set; } 

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Motivations>()
        .HasOne(p => p.Category)
        .WithMany(b => b.Motivations);

    modelBuilder.Entity<Motivations>()
        .HasMany(p => p.HashTag)
        .WithMany(p => p.Motivations)
        .UsingEntity(j => j.ToTable("MotivationsTags"));
    base.OnModelCreating(modelBuilder);
}
}

