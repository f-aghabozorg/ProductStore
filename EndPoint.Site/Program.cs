using Microsoft.EntityFrameworkCore;
using Product_Store.Application.Interfaces.Contexts;
using Product_Store.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
string contectionString = @"Data Source=DESKTOP-7FRVFH5\MSSQLSERVERLAB; Initial Catalog=Product_StoreDb; Integrated Security=True;TrustServerCertificate=True";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(contectionString));
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
