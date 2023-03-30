var CorsPolicy = "localhostCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
                      policy =>
                      {
                          policy.SetIsOriginAllowedToAllowWildcardSubdomains()
                          .SetIsOriginAllowed(origin => true)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CorsPolicy);

app.UseHttpsRedirection();

var searchService = new SearchService();

app.MapGet("/search", (string query) =>
{
    var results = searchService.SearchLocalFilesAndApps(query);
    return results;
})
.WithName("SearchLocalFilesAndApps")
.WithOpenApi();

app.Run();
