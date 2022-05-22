using CRUD_mvc.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//agregar el servicio de la base de datos

//builder.Services.AddDbContext<SistemaControlEntradaSalidaContext>(
  //    options => options.UseInMemoryDatabase(databaseName: "testDB")
//);
string connString = ConfigurationExtensions.GetConnectionString(builder.Configuration, "DefaultConnectionString");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connString)
);

//

var app = builder.Build();

//para verificar la creación del proveedor de datos
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
    }
    catch (System.Exception pException)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(pException, "An error ocurred creating the data base.");
    }
}
//

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
