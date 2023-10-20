using Domain.Resources;
using ErrorOr;

namespace Domain.Errors.Organizations;

public static class OwnCompanyErrors
{
    public static readonly Error NameIsRequired = Error.Validation(
        code: "OwnCompany.NameIsRequired",
        description: Validation.NameIsRequired);
}