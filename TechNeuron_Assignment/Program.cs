using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using TechNeuron_Assignment.Data;
using TechNeuron_Assignment.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Registering Connection string with Asp.net core mvc Dependency injection container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("TechNeuron")));

//Registering IEmployeeRepository repository with Asp.net core mvc Dependency injection container.
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//Registering IEmployeeTaskRepository repository with Asp.net core mvc Dependency injection container.
builder.Services.AddScoped<IEmployeeTaskRepository, EmployeeTaskRepository>();

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
