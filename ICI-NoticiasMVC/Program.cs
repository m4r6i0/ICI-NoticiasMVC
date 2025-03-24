
using ICI_NoticiasMVC.Infrastructure.Configuration;
using ICI_NoticiasMVC.Web.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/Web/Views/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/Web/Views/Shared/{0}.cshtml");
    })
    .AddApplicationPart(typeof(HomeController).Assembly);

builder.Services.AddDependencyServices(builder.Configuration);


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


