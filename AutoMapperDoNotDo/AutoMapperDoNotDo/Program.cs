using Application;
using Dal;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cs));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddAutoMapper(typeof(EmployeeProfile));
builder.Services.AddScoped<EmployeeService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
				app.UseSwagger();
				app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/employees", async (EmployeeService employeeService)
				=> TypedResults.Ok(await employeeService.GetEmployees()));

app.MapGet("/employees/{id}", async (EmployeeService employeeService, int id)
				=> TypedResults.Ok(await employeeService.GetEmployeeById(id)));
app.Run();

