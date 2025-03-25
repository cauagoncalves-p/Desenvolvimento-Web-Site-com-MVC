using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Uc_13_Caua_WebSite.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Uc_13_Caua_WebSiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Uc_13_Caua_WebSiteContext") ?? throw new InvalidOperationException("Connection string 'Uc_13_Caua_WebSiteContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
