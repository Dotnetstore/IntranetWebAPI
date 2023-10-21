using Domain.Entities.Contacts;
using Domain.Entities.Organizations;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Contexts;

public class DotnetstoreIntranetContext : DbContext
{
    public DotnetstoreIntranetContext(DbContextOptions options) : base(options)
    {
        if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator dbCreater)
        {
            if (!dbCreater.CanConnect())
            {
                dbCreater.Create();
            }

            if (!dbCreater.HasTables())
            {
                dbCreater.CreateTables();
            }
        }
    }

    public DbSet<OwnCompany> OwnCompanies => Set<OwnCompany>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserInGroup> UserInGroups => Set<UserInGroup>();
    public DbSet<UserInRole> UserInRoles => Set<UserInRole>();
    public DbSet<RoleInGroup> RoleInGroups => Set<RoleInGroup>();

    public DbSet<ContactInformation> ContactInformation => Set<ContactInformation>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ContactInformation>()
            .Property(q => q.ContactInformationType)
            .HasConversion(
                q => q.Value,
                q => ContactInformationType.FromValue(q)!);

        modelBuilder
            .Entity<User>()
            .HasOne(q => q.OwnCompany)
            .WithMany(q => q.Users)
            .HasForeignKey(q => q.CompanyId);

        modelBuilder
            .Entity<UserInGroup>()
            .HasOne(q => q.Group)
            .WithMany(q => q.UserInGroups)
            .HasForeignKey(q => q.GroupId);

        modelBuilder
            .Entity<UserInGroup>()
            .HasOne(q => q.User)
            .WithMany(q => q.UserInGroups)
            .HasForeignKey(q => q.UserId);

        modelBuilder
            .Entity<UserInRole>()
            .HasOne(q => q.User)
            .WithMany(q => q.UserInRoles)
            .HasForeignKey(q => q.UserId);

        modelBuilder
            .Entity<UserInRole>()
            .HasOne(q => q.Role)
            .WithMany(q => q.UserInRoles)
            .HasForeignKey(q => q.RoleId);

        modelBuilder
            .Entity<RoleInGroup>()
            .HasOne(q => q.Role)
            .WithMany(q => q.RoleInGroups)
            .HasForeignKey(q => q.RoleId);

        modelBuilder
            .Entity<RoleInGroup>()
            .HasOne(q => q.Group)
            .WithMany(q => q.RoleInGroups)
            .HasForeignKey(q => q.GroupId);
    }
}