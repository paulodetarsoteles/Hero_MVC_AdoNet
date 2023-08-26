using Hero_MVC_AdoNet.DAL.Data;
using Hero_MVC_AdoNet.DAL.Repositories;
using Hero_MVC_AdoNet.DAL.Repositories.Interfaces;
using Hero_MVC_AdoNet.Web.Services;
using Hero_MVC_AdoNet.Web.Services.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<IHeroRepository, HeroRepository>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        builder.Services.AddScoped<ISecretRepository, SecretRepository>();
        builder.Services.AddScoped<IWeaponRepository, WeaponRepository>();

        builder.Services.AddScoped<IHeroService, HeroService>();
        builder.Services.AddScoped<IMovieService, MovieService>();
        builder.Services.AddScoped<ISecretService, SecretService>();
        builder.Services.AddScoped<IWeaponService, WeaponService>();

        builder.Services.Configure<ConnectionSetting>(builder.Configuration.GetSection("ConnectionStrings"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}