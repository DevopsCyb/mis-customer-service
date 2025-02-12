using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;
using Mis.Services.Customer.Repository;
using Mis.Services.Customer.Api.Controllers;
using Mis.Services.Customer.Api.Repository;
using Mis.Services.Customer.Api.Models;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
{
    
    builder.Services.AddDbContext<Mis.Services.Customer.Api.Models.MisServicesCustomerDatabaseContext>(item =>
    item.UseSqlServer(builder.Configuration.GetConnectionString("CustomerServiceConnectionString")));
}
else
{

    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    // Load environment-specific configuration
    builder.Configuration.AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true);
    var keyVaultUri = builder.Configuration["AzureKeyVault:keyVaultURL"];
    var dbSecret  = builder.Configuration["AzureKeyVault:CustomerDbSecretName"];
    var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());
   // KeyVaultSecret secret = client.GetSecret(dbSecret);

    builder.Services.AddDbContext<MisServicesCustomerDatabaseContext>(item => item.UseSqlServer(client.GetSecret($"{dbSecret}").Value.Value.ToString()));
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<MisServicesCustomerDatabaseContext>(x => x.UseSqlServer(Client.GetSecret("CustomerServiceConnectionString").Value.Value.ToString()));

//builder.Services.AddDbContext<MisServicesCustomerDatabaseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("CustomerServiceConnectionString")));

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowReactApp", builder => {
        builder.AllowAnyOrigin() // Replace with the URL of your React application
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

