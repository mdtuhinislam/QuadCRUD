using Microsoft.EntityFrameworkCore;
using QuadCRUD.AppDbContext;
using QuadCRUD.Interfaces;
using QuadCRUD.Repository.Base;
using QuadCRUD.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionStr"));
});
builder.Services.AddTransient<IStudentServices, StudentServices>();
builder.Services.AddTransient<IClassService, ClassServices>();
builder.Services.AddTransient<IStudentRepo, StudentRepo>();

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
