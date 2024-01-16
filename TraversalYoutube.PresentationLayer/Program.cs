using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Serilog;
using System.Reflection;
using TraversalYoutube.BusinessLayer.Container;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.CQRS.Handlers.DestinationHandlers;
using TraversalYoutube.PresentationLayer.Models;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

var builder = WebApplication.CreateBuilder(args);

var _loggerer = new LoggerConfiguration().MinimumLevel.Error()   //bu kod par�as�nda serilog.aspnetcore indirdikten sonra yazd�k bu �ekilde �al���yor 
    .WriteTo.File("C:\\Users\\MSI\\Desktop\\Yaz�l�m\\Repo\\TraversalYoutube\\TraversalYoutube.PresentationLayer\\wwwroot\\Logs\\Logger.log",
    rollingInterval: RollingInterval.Day).CreateLogger();
builder.Logging.AddSerilog(_loggerer);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<GetAllDestinationQueryHandler>(); //Manuel CQRS i�in her bir handler i�in bir scope tan�mlam��t�k
builder.Services.AddScoped<GetDestinationByIDQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<DeleteDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();

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
