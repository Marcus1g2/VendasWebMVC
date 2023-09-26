using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using VendasWebMvc.Data;
using VendasWebMvc.Services;

var builder = WebApplication.CreateBuilder(args);

string mySqlConnection =
              builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<VendasWebMvcContext>(options =>
    options.UseMySql(mySqlConnection,
                      ServerVersion.AutoDetect(mySqlConnection)));



builder.Services.AddScoped<ServicoDeSedding>();
builder.Services.AddScoped<VendedorServicos>();


builder.Services.AddScoped<DepartamentosServicos>();


builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var seedingService = serviceProvider.GetRequiredService<ServicoDeSedding>();
    seedingService.Create();
}






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
