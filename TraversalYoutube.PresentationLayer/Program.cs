using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Serilog;
using System.Reflection;
using TraversalYoutube.BusinessLayer.Container;
using TraversalYoutube.BusinessLayer.ValidationRules;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

var _loggerer = new LoggerConfiguration().MinimumLevel.Error()   //bu kod parçasýnda serilog.aspnetcore indirdikten sonra yazdýk bu þekilde çalýþýyor 
    .WriteTo.File("C:\\Users\\MSI\\Desktop\\Yazýlým\\Repo\\TraversalYoutube\\TraversalYoutube.PresentationLayer\\wwwroot\\Logs\\Logger.log",
    rollingInterval: RollingInterval.Day).CreateLogger();
builder.Logging.AddSerilog(_loggerer);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();

builder.Services.ContainerDependencies();

builder.Services.RegisterValidator();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
