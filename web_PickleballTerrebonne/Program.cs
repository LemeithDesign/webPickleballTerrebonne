using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using web_PickleballTerrebonne.Data.Contexts;
using web_PickleballTerrebonne.Data.Depot;
using web_PickleballTerrebonne.Hubs;
using web_PickleballTerrebonne.ObjetTransfertDonnee;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

var services = builder.Services;

//string? connString = builder.Configuration.GetConnectionString("DefaultConnection");
//if(string.IsNullOrEmpty(connString))
//{
//    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//}

if (environment.IsDevelopment())
{
    // Développement
    services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=../web_PickleballTerrebonne.Data/Databases/DataDb.db", b => b.MigrationsAssembly("web_PickleballTerrebonne.Data")));
}
else
{
    // Production
    services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=./Databases/DataDb.db", b => b.MigrationsAssembly("web_PickleballTerrebonne.Data")));
}

#region Injections
services.AddScoped<IInscriptionData, InscriptionData>();
#endregion Injections


// Mapping
var mapsterConfig = TypeAdapterConfig.GlobalSettings;
mapsterConfig.Scan(typeof(MapsterConfig).Assembly);

services.AddSingleton(mapsterConfig);
services.AddScoped<ServiceMapper>();
services.AddScoped<IMapper>(sp => sp.GetRequiredService<ServiceMapper>());

builder.Services.AddRazorPages(opt =>
    opt.Conventions.AddPageRoute("/Inscription", "")
    );

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{

//}
//else
//{
//    //app.UseExceptionHandler("/Error");
//    app.UseHsts();
//}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
