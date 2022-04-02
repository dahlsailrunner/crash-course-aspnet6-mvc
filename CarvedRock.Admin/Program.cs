using CarvedRock.Admin.Data;
using CarvedRock.Admin.DomainLogic;
using CarvedRock.Admin.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductContext>();
builder.Services.AddScoped<ICarvedRockRepository, CarvedRockRepository>();
builder.Services.AddScoped<IProductLogic, ProductLogic>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ProductContext>();
    context.Database.Migrate();

    if (app.Environment.IsDevelopment())
    {
        context.SeedInitialData();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
}
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
