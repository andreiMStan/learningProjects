using Microsoft.EntityFrameworkCore;
using NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Core;
using NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Data;

var builder = WebApplication.CreateBuilder(args);

/// Utilising Unit of work
//implementing unit of work in web api
//created repo folder  where we have created a generit repository interface
//where we have specified all different commands that we want to implement there
//create a I unit of work were we are mapping the different interfaces for out unit of work
// then we have implemented a default implementation withing the repo for all the generic interfaces
// them we have created special implementation for the drivers where we override certain action so that 
// we can add a custom command for our database which has got driver by number
// once done we have writen our unit of work implementation , we were able to create implementation for the interfaces
//once done wired up and updated controller 




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>(options 
	=> options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//Unit of work = a way to comunicate to db without refering to db directly
//Service base approach to db 
//allowing us to inject in controller then refer to it
//