using Microsoft.EntityFrameworkCore;
using Models;

namespace Persistence;

public partial class UserDbContext : DbContext, IUserDbContext
{
    public UserDbContext()
    {
    }

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClaimHistory> ClaimHistories { get; set; }

    public virtual DbSet<ClaimOffice> ClaimOffices { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClaimHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClaimHis__3214EC074D50EBE4");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB2FAD755A13");

            entity.Property(e => e.PermissionId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Role).WithMany(p => p.Permissions).HasConstraintName("FK__Permissio__RoleI__6C190EBB");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AD046E6B7");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Test__3213E83FF89F7685");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasMany(d => d.Roles).WithMany(p => p.Us)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRoles__RoleI__693CA210"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRoles__UsId__68487DD7"),
                    j =>
                    {
                        j.HasKey("UsId", "RoleId").HasName("PK__UserRole__058E4FBEB7A2D518");
                        j.ToTable("UserRoles");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
