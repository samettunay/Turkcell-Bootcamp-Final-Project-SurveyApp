using SurveyApp.Infrastructure.Data;
using SurveyApp.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Mvc.Extensions;
using Microsoft.AspNetCore.Identity;
using SurveyApp.Mvc.Data;
using SurveyApp.Mvc.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapProfile));

var connectionStringSurvey = builder.Configuration.GetConnectionString("db");
var identityConnectionString = builder.Configuration.GetConnectionString("SurveyAppMvcContextConnection");

builder.Services.AddDbContext<SurveyAppMvcContext>(options => options.UseSqlServer(identityConnectionString));

builder.Services.AddDefaultIdentity<SurveyAppMvcUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SurveyAppMvcContext>();

builder.Services.AddInjections(connectionStringSurvey);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<SurveyDbContext>();
context.Database.EnsureCreated();
DbSeeding.SeedDatabase(context);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
