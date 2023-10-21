namespace Presentation.Swagger;

public static class ApiEndPoints
{
    private const string ApiBase = "api";

    public static class OwnCompanyV1
    {
        private const string Base = $"{ApiBase}/V1/owncompanies";

        public const string GetAll = Base;
    }
}