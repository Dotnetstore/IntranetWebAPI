using Domain.Entities.Contacts;
using FluentAssertions;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using TestHelper.FakeData;

namespace Infrastructure.Tests.Contexts;

public class DotnetstoreIntranetContextTests : IDisposable
{
    private readonly DbContextOptions<DotnetstoreIntranetContext> _options;
    private readonly DotnetstoreIntranetContext _context;

    public DotnetstoreIntranetContextTests()
    {
        _options = new DbContextOptionsBuilder<DotnetstoreIntranetContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new DotnetstoreIntranetContext(_options);
    }

    [Fact]
    public void Can_Add_User_To_Database()
    {
        // Arrange
        var user = OrganizationFakeData.GenerateUserFakeData(1).Single();

        // Act
        _context.Users.Add(user);
        _context.SaveChanges();

        // Assert
        var retrievedUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
        retrievedUser.Should().BeEquivalentTo(user);
    }

    [Fact]
    public void Can_Retrieve_ContactInformation_From_Database()
    {
        // Arrange
        var contactInfo = ContactFakeData.GenerateOwnCompanyFakeData(1).Single();
    
        // Act
        _context.ContactInformation.Add(contactInfo);
        _context.SaveChanges();
    
        // Assert
        var retrievedContactInfo = _context.ContactInformation.FirstOrDefault(ci => ci.Id == contactInfo.Id);
        retrievedContactInfo.Should().BeEquivalentTo(contactInfo);
    }

    [Fact]
    public void Can_add_group_to_database()
    {
        // Arrange
        var entity = OrganizationFakeData.GenerateGroupFakeData(1).Single();

        // Act
        _context.Groups.Add(entity);
        _context.SaveChanges();

        // Assert
        var retrievedEntity = _context.Groups.FirstOrDefault(u => u.Id == entity.Id);
        retrievedEntity.Should().BeEquivalentTo(entity);
    }

    [Fact]
    public void Can_add_role_to_database()
    {
        // Arrange
        var entity = OrganizationFakeData.GenerateRoleFakeData(1).Single();

        // Act
        _context.Roles.Add(entity);
        _context.SaveChanges();

        // Assert
        var retrievedEntity = _context.Roles.FirstOrDefault(u => u.Id == entity.Id);
        retrievedEntity.Should().BeEquivalentTo(entity);
    }

    [Fact]
    public void Can_add_role_in_group_to_database()
    {
        // Arrange
        var entity = OrganizationFakeData.GenerateRoleInGroupFakeData(1).Single();

        // Act
        _context.RoleInGroups.Add(entity);
        _context.SaveChanges();

        // Assert
        var retrievedEntity = _context.RoleInGroups.FirstOrDefault(u => u.Id == entity.Id);
        retrievedEntity.Should().BeEquivalentTo(entity);
    }

    [Fact]
    public void Can_add_user_in_group_to_database()
    {
        // Arrange
        var entity = OrganizationFakeData.GenerateUserInGroupFakeData(1).Single();

        // Act
        _context.UserInGroups.Add(entity);
        _context.SaveChanges();

        // Assert
        var retrievedEntity = _context.UserInGroups.FirstOrDefault(u => u.Id == entity.Id);
        retrievedEntity.Should().BeEquivalentTo(entity);
    }

    [Fact]
    public void Can_add_user_in_role_to_database()
    {
        // Arrange
        var entity = OrganizationFakeData.GenerateUserInRoleFakeData(1).Single();

        // Act
        _context.UserInRoles.Add(entity);
        _context.SaveChanges();

        // Assert
        var retrievedEntity = _context.UserInRoles.FirstOrDefault(u => u.Id == entity.Id);
        retrievedEntity.Should().BeEquivalentTo(entity);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}