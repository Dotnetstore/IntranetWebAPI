using Bogus;
using Domain.Common;
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
}