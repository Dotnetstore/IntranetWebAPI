using Bogus;
using Domain.Entities.Contacts;
using Domain.Enums;

namespace TestHelper.FakeData;

public static class ContactFakeData
{
    private const int Seed = 8675309;
    private const string Lang = "sv";

    public static IEnumerable<EmailInformation> GenerateEmailInformationFakeData(int quantity)
    {
        Randomizer.Seed = new Random(Seed);

        var faker = new Faker<EmailInformation>(Lang)
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
            .RuleFor(q => q.Text, f => f.Person.Email)
            .RuleFor(q => q.EmailType, EmailType.RegistrationEmail);
        
        return faker.Generate(quantity);
    }
}