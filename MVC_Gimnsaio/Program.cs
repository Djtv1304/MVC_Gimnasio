using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MVC_Gimnsaio.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAPIServiceMembresia, APIServiceMembresia>();
builder.Services.AddScoped<IAPIServiceMiembro, APIServiceMiembro>();
builder.Services.AddScoped<IAPIServicePago, APIServicePago>();
builder.Services.AddScoped<IAPIServiceVisita, APIServiceVisita>();
builder.Services.AddScoped<IAPIServiceUsuario, APIServiceUsuario>();

// Agregar el servicio de IActionContextAccessor aqu�
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

// Agregar el servicio de sesi�n aqu�
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    // Establecer un tiempo de espera de la sesi�n, por ejemplo, 40 minutos
    options.IdleTimeout = TimeSpan.FromMinutes(40);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

// Agregar el middleware de sesi�n aqu�
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
