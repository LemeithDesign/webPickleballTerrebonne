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
using webPickleballTerrebonne.Data.Constantes;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

var services = builder.Services;

//if (environment.IsDevelopment())
//{
//    // Développement
//    services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=../webPickleballTerrebonne.Data/Databases/DataDb.db", b => b.MigrationsAssembly("webPickleballTerrebonne.Data")));
//}
//else
//{
//    // Production
//    services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=./Databases/DataDb.db", b => b.MigrationsAssembly("webPickleballTerrebonne.Data")));
//}

#region Injections
//services.AddScoped<IInscriptionData, InscriptionData>();
//services.AddScoped<IMembreData, MembreData>();
//services.AddScoped<IPlageHoraireData, PlageHoraireData>();
//services.AddScoped<IParticipationData, ParticipationData>();
//services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaimsPrincipalFactory>();
#endregion Injections

#region mapping
//var mapsterConfig = TypeAdapterConfig.GlobalSettings;
//mapsterConfig.Scan(typeof(MapsterConfig).Assembly);

//services.AddSingleton(mapsterConfig);
//services.AddScoped<ServiceMapper>();
//services.AddScoped<IMapper>(sp => sp.GetRequiredService<ServiceMapper>());
#endregion mapping

#region Identity
//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<DataContext>();

//// Vérification / création des rôles au démarrage de l'application
//builder.Services.AddTransient<IHostedService, RoleService>();

////if (environment.IsDevelopment())
////{ }
////else
////{ 
////}
//builder.Services.AddAuthorizationBuilder()
//    .AddPolicy(NomsStrategiesAuthorisation.Admin, policy => policy.RequireRole(NomsRoles.Admin))
//    .AddPolicy(NomsStrategiesAuthorisation.CA, policy => policy.RequireRole(NomsRoles.Admin, NomsRoles.CA))
//    .AddPolicy(NomsStrategiesAuthorisation.Membre, policy => policy.RequireRole(NomsRoles.Admin, NomsRoles.CA, NomsRoles.Membre))
//    .AddPolicy(NomsStrategiesAuthorisation.User, policy => policy.RequireRole(NomsRoles.Admin, NomsRoles.CA, NomsRoles.Membre, NomsRoles.Admin));
#endregion Identity

//builder.Services.AddRazorPages(opt => opt.Conventions.AddPageRoute("/Inscription", ""));
builder.Services.AddRazorPages();

var app = builder.Build();

#region Seed DB
//using var scope = app.Services.CreateScope();
//var scopeServices = scope.ServiceProvider;
//var dbContext = scopeServices.GetRequiredService<DataContext>();
//var gestMembres = scopeServices.GetRequiredService<IMembreData>();
//var userStore = scopeServices.GetRequiredService<IUserStore<ApplicationUser>>();
//var userManager = scopeServices.GetRequiredService<UserManager<ApplicationUser>>();
//var roleManager = scopeServices.GetRequiredService<RoleManager<IdentityRole>>();

//dbContext.Database.EnsureDeleted();
//dbContext.Database.Migrate();
//dbContext.Database.EnsureCreated();

//DbInitializer dbInitializer = new DbInitializer(gestMembres, userStore, userManager, roleManager);
//dbInitializer.Seed(dbContext).Wait();
#endregion Seed DB



if (environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    //app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//if (environment.IsDevelopment())
//{
//}
//else
//{
//}

//app.UseAuthentication();
//app.UseAuthorization();

app.MapRazorPages();

app.Run();