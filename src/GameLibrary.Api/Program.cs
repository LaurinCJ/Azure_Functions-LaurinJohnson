using GameLibrary.Business;
using GameLibrary.Data;
using GameLibrary.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("GameLibrary")
    ?? throw new InvalidOperationException("Missing GameLibrary connection string.");
builder.Services.AddSingleton(new SqlConnectionFactory(connectionString));
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IFranchiseRepository, FranchiseRepository>();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<GameManager>();
builder.Services.AddScoped<FranchiseManager>();
builder.Services.AddScoped<PlatformManager>();
builder.Services.AddHttpClient("AzureFunctions", client =>
{
    var baseUrl = builder.Configuration["AzureFunctions:BaseUrl"]
        ?? throw new InvalidOperationException("Missing AzureFunctions:BaseUrl.");
    client.BaseAddress = new Uri(baseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
    var key = builder.Configuration["AzureFunctions:FunctionKey"];
    if (!string.IsNullOrWhiteSpace(key))
    {
        client.DefaultRequestHeaders.Add("x-functions-key", key);
    }
});
builder.Services.AddScoped<CloudManager>();

var app = builder.Build();
app.MapGet("/", () => Results.Text("Project 6 API host is running. Implement the TODO controllers and business methods. This does not check the database."));
app.MapControllers();
app.Run();
