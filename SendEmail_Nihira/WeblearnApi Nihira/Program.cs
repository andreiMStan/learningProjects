using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Diagnostics.SymbolStore;
using System.Text;
using WeblearnApi_Nihira.Container;
using WeblearnApi_Nihira.Helper;
using WeblearnApi_Nihira.Modal;
using WeblearnApi_Nihira.Repos;
using WeblearnApi_Nihira.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IRefreshHandler, RefreshHandler>();
builder.Services.AddDbContext<LearndataContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString
("DefaultConnection"))) ;

//builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

var _authkey = builder.Configuration.GetValue<string>("JwtSettings:securitykey"); 
builder.Services.AddAuthentication(
 item =>
 {
  item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
 }).AddJwtBearer(item=> {
  item.RequireHttpsMetadata = true;
  item.SaveToken = true;
  item.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
  {
   ValidateIssuerSigningKey = true,
   IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authkey)),
   ValidateIssuer = false,
   ValidateAudience = false,
   ClockSkew = TimeSpan.Zero
  };
 });

var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddCors(p => p.AddPolicy("corspolicy", build => {
 build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
 /*("https://domain1.com", "http://domain2.com")*/
}));

builder.Services.AddCors(p => p.AddPolicy("corspolicy1", build => {
 build.WithOrigins("https://domain3.com").AllowAnyMethod().AllowAnyHeader();
 
 }));
builder.Services.AddCors(p => p.AddDefaultPolicy(build => {
 build.WithOrigins("https://domain3.com").AllowAnyMethod().AllowAnyHeader();
 
 }));

builder.Services.AddRateLimiter(_ => _.AddFixedWindowLimiter(policyName: "fixedwindow",
 options => {
 options.Window = TimeSpan.FromSeconds(10);
 options.PermitLimit = 1;
 options.QueueLimit = 0;
 options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
}
 ).RejectionStatusCode=401);
string logpath = builder.Configuration.GetSection("Logging:Logpath").Value;
var _logger = new LoggerConfiguration()
 .MinimumLevel.Information()
 .MinimumLevel.Debug()
 //.MinimumLevel.Error()

 .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
 .Enrich.FromLogContext()
 .WriteTo.File(logpath)
 .CreateLogger();

var _jwtsetting = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(_jwtsetting);

builder.Logging.AddSerilog(_logger);

var app = builder.Build();

app.UseRateLimiter();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 app.UseSwagger();
 app.UseSwaggerUI();
}

//app.UseCors("corspolicy");
app.UseCors(); // with default policy
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
