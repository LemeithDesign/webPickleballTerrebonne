using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using web_PickleballTerrebonne.Claims;
using web_PickleballTerrebonne.Data.Contexts;
using web_PickleballTerrebonne.Data.Depot;
using web_PickleballTerrebonne.Data.Entites;
using web_PickleballTerrebonne.ObjetTransfertDonnee;
using web_PickleballTerrebonne.Services;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

var services = builder.Services;

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
//services.AddScoped<IInscriptionData, InscriptionData>();
services.AddScoped<IMembreData, MembreData>();
services.AddScoped<IMembreService, MembreService>();
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