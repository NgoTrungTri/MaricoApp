using Microsoft.EntityFrameworkCore;
using Models;

namespace Mcsg.User.Infrastructure.Persistence;

public partial class UserDbContext : DbContext
{
    public UserDbContext()
    {
    }

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Models.User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Test__3213E83FF89F7685");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Models.User>(entity =>
        {
            entity.HasKey(e => e.UsId).HasName("PK__Users__BD21E35FEC719FE3");

            entity.Property(e => e.UsId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
