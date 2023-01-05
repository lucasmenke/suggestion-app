namespace SuggestionAppUI
{
    public static class RegisterServices
    {
        // extension methode (this...)
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            // caching is automatically build into web projects -> no nuget package needed like in the SuggestionAppLibrary
            builder.Services.AddMemoryCache();

            // AddSingleton -> one instance overall (only when the DataAccess classes don't store specific data)
            // AddScoped -> one instance per user
            builder.Services.AddSingleton<IDbConnection, DbConnection>();
            builder.Services.AddSingleton<ICategoryData, MongoCategoryData>();
            builder.Services.AddSingleton<IStatusData, MongoStatusData>();
            builder.Services.AddSingleton<ISuggestionData, MongoSuggestionData>();
            builder.Services.AddSingleton<IUserData, MongoUserData>();
        }
    }
}
