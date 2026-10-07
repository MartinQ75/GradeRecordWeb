using GradeRecord.Class;
using GradeRecord.Web;
using GradeRecord.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

// Confiura DBCOntext para la base de datos
builder.Services.AddDbContext<GradeRecordDB>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuracion de Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<GradeRecordDB>()
    .AddDefaultTokenProviders();

// Configura de cookies para autenticacion
builder.Services.ConfigureApplicationCookie(async options =>
{
    options.LoginPath = "/Login";
    options.AccessDeniedPath = "/Home/AccesDenied";
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleInitializer.SeedRolesAsync(services);
    await UserInitializer.SeedUsersAsync(services);
    await AcademicInitializer.SeedAcademicDataAsync(services);
}


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
