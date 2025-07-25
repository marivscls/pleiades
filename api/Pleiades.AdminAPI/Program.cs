using Pleiades.Infrastructure.Data.Database;
using Pleiades.Infrastructure.Documentation.OpenApi;
using Pleiades.Infrastructure.IoC.ServiceExtensions;
using Pleiades.Infrastructure.IoC.ServiceExtensions.JWT;
using Pleiades.Infrastructure.Settings;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Default Setup
builder.Services.AddControllers();

// Db Context
builder.Services.AddAppDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));

// Logging
Log.Logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .Enrich.WithEnvironmentName()
  .WriteTo.Console()
  .CreateLogger();

builder.Host.UseSerilog();

// Repositories
builder.Services.AddRepositories();

// Mappers
//builder.Services.AddMappers();

// Use Cases
builder.Services.AddUseCases();

// Security
builder.Services.AddSecurity(builder.Configuration);

// Auth
builder.Services.AddJwtAuth(builder.Configuration);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.Configure<OpenApiSettings>(
  builder.Configuration.GetSection("OpenApiSettings"));
builder.Services.AddOpenApi("v1",
  options => { options.AddDocumentTransformer<BearerSecuritySchemeTransformer>(); });

// Cors
builder.Services.AddCors(options => {
  options.AddPolicy("AdminDefaultCorsPolicy", policy => {
    policy.WithOrigins("http://localhost:4200")
      .AllowAnyHeader()
      .AllowAnyMethod()
      .AllowCredentials();
  });
});

var app = builder.Build();

// Middlewares
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseCors("AdminDefaultCorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

// Run
app.MapControllers();

if (app.Environment.IsDevelopment()) {
  app.MapOpenApi();
  app.MapScalarApiReference(options => {
    options.Title = "Pleiades API";
    options.Theme = ScalarTheme.BluePlanet;
    options.ShowSidebar = true;
    options.AddPreferredSecuritySchemes("Bearer");
    options.AddHttpAuthentication("Bearer",
      _ => { });
  });
  PrepDb.PrepPopulation(app);
}

if (!app.Environment.IsDevelopment()) {
  app.UseHsts();
}

app.Run();

public abstract partial class Program;
