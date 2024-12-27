using CloudCustomers.Api.Config;
using CloudCustomers.Api.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);
// Add services to the container.



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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


void ConfigureServices(IServiceCollection services)
{
 services.Configure<UserApiOption>(builder.Configuration.GetSection("UsersApiOptions"));
 services.AddTransient<IUserService, UserService>();
 services.AddHttpClient<IUserService, UserService>();
  //singleteon inces lives for lifetime of application 
  
 //scopped which is the http request itself 
 //transient at any point we requiere a new instance is created
}