using Microsoft.EntityFrameworkCore;
using Models;

public interface IUserDbContext
{
    DbSet<ClaimHistory> ClaimHistories { get; }
    DbSet<ClaimOffice> ClaimOffices { get; }
    DbSet<Permission> Permissions { get; }
    DbSet<Role> Roles { get; }
    DbSet<Test> Tests { get; }
    DbSet<User> Users { get; }
    DbSet<UserRole> UserRoles { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
