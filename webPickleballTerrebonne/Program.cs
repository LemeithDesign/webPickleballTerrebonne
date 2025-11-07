using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webPickleballTerrebonne.Claims;
using webPickleballTerrebonne.Data.Contexts;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee;
using webPickleballTerrebonne.Services;
using webPickleballTerrebonne.Data.Initializer;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

var services = builder.Services;

if (environment.IsDevelopment())
{
    // Développement
    services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=../webPickleballTerrebonne.Data/Databases/DataDb.db", b => b.MigrationsAssembly("webPickleballTerrebonne.Data")));
}
else
{
    // Production
    services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=./Databases/DataDb.db", b => b.MigrationsAssembly("webPickleballTerrebonne.Data")));
}

#region Injections
//services.AddScoped<IInscriptionData, InscriptionData>();
services.AddScoped<IMembreData, MembreData>();
services.AddScoped<IMembreService, MembreService>();
services.AddScoped<ISeanceData, SeanceData>();
services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaimsPrincipalFactory>();
#endregion Injections

#region mapping
var mapsterConfig = TypeAdapterConfig.GlobalSettings;
mapsterConfig.Scan(typeof(MapsterConfig).Assembly);

services.AddSingleton(mapsterConfig);
services.AddScoped<ServiceMapper>();
services.AddScoped<IMapper>(sp => sp.GetRequiredService<ServiceMapper>());
#endregion mapping

#region Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DataContext>();
#endregion Identity

//builder.Services.AddRazorPages(opt => opt.Conventions.AddPageRoute("/Inscription", ""));
builder.Services.AddRazorPages();

var app = builder.Build();

// Seeder la base de données:
using var scope = app.Services.CreateScope();

var scopeServices = scope.ServiceProvider;
var dbContext = scopeServices.GetRequiredService<DataContext>();
var gestMembres = scopeServices.GetRequiredService<IMembreData>();
var userStore = scopeServices.GetRequiredService<IUserStore<ApplicationUser>>();
var userManager = scopeServices.GetRequiredService<UserManager<ApplicationUser>>();

dbContext.Database.EnsureDeleted();
dbContext.Database.Migrate();
dbContext.Database.EnsureCreated();

DbInitializer dbInitializer = new DbInitializer(gestMembres, userStore, userManager);
dbInitializer.Seed(dbContext).Wait();

    app.UseDeveloperExceptionPage();
if (app.Environment.IsDevelopment())
{

}
else
{
    //app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();