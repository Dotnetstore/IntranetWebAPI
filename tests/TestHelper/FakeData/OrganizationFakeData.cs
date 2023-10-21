using Bogus;
using Domain.Entities.Organizations;

namespace TestHelper.FakeData;

public sealed class OrganizationFakeData
{
    private const int Seed = 8675309;
    private const string Lang = "sv";

    public static IEnumerable<OwnCompany> GenerateOwnCompanyFakeData(int quantity)
    {
        Randomizer.Seed = new Random(Seed);

        var faker = new Faker<OwnCompany>(Lang)
            .RuleFor(q => q.Id, f => f.Random.Guid())
            .RuleFor(q => q.CreatedBy, f => f.Random.Guid())
            .RuleFor(q => q.CreatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.LastUpdatedBy, f => f.Random.Guid())
            .RuleFor(q => q.LastUpdatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.DeletedBy, f => f.Random.Guid())
            .RuleFor(q => q.DeletedDate, DateTimeOffset.Now)
            .RuleFor(q => q.IsDeleted, f => f.Random.Bool())
            .RuleFor(q => q.IsSystem, f => f.Random.Bool())
            .RuleFor(q => q.IsGdpr, f => f.Random.Bool())
            .RuleFor(q => q.Name, f => f.Company.CompanyName())
            .RuleFor(q => q.CorporateId, f => f.Random.Int(10).ToString());

        return faker.Generate(quantity);
    }

    public static IEnumerable<User> GenerateUserFakeData(int quantity)
    {
        Randomizer.Seed = new Random(Seed);

        var faker = new Faker<User>(Lang)
            .RuleFor(q => q.Id, f => f.Random.Guid())
            .RuleFor(q => q.CreatedBy, f => f.Random.Guid())
            .RuleFor(q => q.CreatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.LastUpdatedBy, f => f.Random.Guid())
            .RuleFor(q => q.LastUpdatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.DeletedBy, f => f.Random.Guid())
            .RuleFor(q => q.DeletedDate, DateTimeOffset.Now)
            .RuleFor(q => q.IsDeleted, f => f.Random.Bool())
            .RuleFor(q => q.IsSystem, f => f.Random.Bool())
            .RuleFor(q => q.IsGdpr, f => f.Random.Bool())
            .RuleFor(q => q.LastName, f => f.Person.LastName)
            .RuleFor(q => q.FirstName, f => f.Person.FirstName)
            .RuleFor(q => q.MiddleName, f => f.Person.FirstName)
            .RuleFor(q => q.EnglishName, f => f.Person.FirstName)
            .RuleFor(q => q.SocialSecurityNumber, f => f.Random.String2(10))
            .RuleFor(q => q.Username, f => f.Person.UserName)
            .RuleFor(q => q.Password, f => f.Random.String2(50))
            .RuleFor(q => q.Salt1, f => f.Random.String2(50))
            .RuleFor(q => q.Salt2, f => f.Random.String2(50))
            .RuleFor(q => q.Salt3, f => f.Random.String2(50))
            .RuleFor(q => q.Salt4, f => f.Random.String2(50))
            .RuleFor(q => q.IsMale, f => f.Random.Bool());
        
        return faker.Generate(quantity);
    }
    
    public static IEnumerable<Group> GenerateGroupFakeData(int quantity)
    {
        Randomizer.Seed = new Random(Seed);

        var faker = new Faker<Group>(Lang)
            .RuleFor(q => q.Id, f => f.Random.Guid())
            .RuleFor(q => q.CreatedBy, f => f.Random.Guid())
            .RuleFor(q => q.CreatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.LastUpdatedBy, f => f.Random.Guid())
            .RuleFor(q => q.LastUpdatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.DeletedBy, f => f.Random.Guid())
            .RuleFor(q => q.DeletedDate, DateTimeOffset.Now)
            .RuleFor(q => q.IsDeleted, f => f.Random.Bool())
            .RuleFor(q => q.IsSystem, f => f.Random.Bool())
            .RuleFor(q => q.IsGdpr, f => f.Random.Bool())
            .RuleFor(q => q.Name, f => f.Random.String2(10));
        
        return faker.Generate(quantity);
    }
    
    public static IEnumerable<Role> GenerateRoleFakeData(int quantity)
    {
        Randomizer.Seed = new Random(Seed);

        var faker = new Faker<Role>(Lang)
            .RuleFor(q => q.Id, f => f.Random.Guid())
            .RuleFor(q => q.CreatedBy, f => f.Random.Guid())
            .RuleFor(q => q.CreatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.LastUpdatedBy, f => f.Random.Guid())
            .RuleFor(q => q.LastUpdatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.DeletedBy, f => f.Random.Guid())
            .RuleFor(q => q.DeletedDate, DateTimeOffset.Now)
            .RuleFor(q => q.IsDeleted, f => f.Random.Bool())
            .RuleFor(q => q.IsSystem, f => f.Random.Bool())
            .RuleFor(q => q.IsGdpr, f => f.Random.Bool())
            .RuleFor(q => q.Name, f => f.Random.String2(10));
        
        return faker.Generate(quantity);
    }
    
    public static IEnumerable<UserInGroup> GenerateUserInGroupFakeData(int quantity)
    {
        Randomizer.Seed = new Random(Seed);

        var faker = new Faker<UserInGroup>(Lang)
            .RuleFor(q => q.Id, f => f.Random.Guid())
            .RuleFor(q => q.CreatedBy, f => f.Random.Guid())
            .RuleFor(q => q.CreatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.LastUpdatedBy, f => f.Random.Guid())
            .RuleFor(q => q.LastUpdatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.DeletedBy, f => f.Random.Guid())
            .RuleFor(q => q.DeletedDate, DateTimeOffset.Now)
            .RuleFor(q => q.IsDeleted, f => f.Random.Bool())
            .RuleFor(q => q.IsSystem, f => f.Random.Bool())
            .RuleFor(q => q.IsGdpr, f => f.Random.Bool())
            .RuleFor(q => q.GroupId, f => f.Random.Guid())
            .RuleFor(q => q.UserId, f => f.Random.Guid());
        
        return faker.Generate(quantity);
    }
    
    public static IEnumerable<UserInRole> GenerateUserInRoleFakeData(int quantity)
    {
        Randomizer.Seed = new Random(Seed);

        var faker = new Faker<UserInRole>(Lang)
            .RuleFor(q => q.Id, f => f.Random.Guid())
            .RuleFor(q => q.CreatedBy, f => f.Random.Guid())
            .RuleFor(q => q.CreatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.LastUpdatedBy, f => f.Random.Guid())
            .RuleFor(q => q.LastUpdatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.DeletedBy, f => f.Random.Guid())
            .RuleFor(q => q.DeletedDate, DateTimeOffset.Now)
            .RuleFor(q => q.IsDeleted, f => f.Random.Bool())
            .RuleFor(q => q.IsSystem, f => f.Random.Bool())
            .RuleFor(q => q.IsGdpr, f => f.Random.Bool())
            .RuleFor(q => q.RoleId, f => f.Random.Guid())
            .RuleFor(q => q.UserId, f => f.Random.Guid());
        
        return faker.Generate(quantity);
    }
    
    public static IEnumerable<RoleInGroup> GenerateRoleInGroupFakeData(int quantity)
    {
        Randomizer.Seed = new Random(Seed);

        var faker = new Faker<RoleInGroup>(Lang)
            .RuleFor(q => q.Id, f => f.Random.Guid())
            .RuleFor(q => q.CreatedBy, f => f.Random.Guid())
            .RuleFor(q => q.CreatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.LastUpdatedBy, f => f.Random.Guid())
            .RuleFor(q => q.LastUpdatedDate, DateTimeOffset.Now)
            .RuleFor(q => q.DeletedBy, f => f.Random.Guid())
            .RuleFor(q => q.DeletedDate, DateTimeOffset.Now)
            .RuleFor(q => q.IsDeleted, f => f.Random.Bool())
            .RuleFor(q => q.IsSystem, f => f.Random.Bool())
            .RuleFor(q => q.IsGdpr, f => f.Random.Bool())
            .RuleFor(q => q.GroupId, f => f.Random.Guid())
            .RuleFor(q => q.RoleId, f => f.Random.Guid());
        
        return faker.Generate(quantity);
    }
}