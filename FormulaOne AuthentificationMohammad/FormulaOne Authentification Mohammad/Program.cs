using FormulaOne_Authentification_Mohammad.Configuration;
using FormulaOne_Authentification_Mohammad.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//allowing to use the configuration innjecting in di
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

builder.Services.AddAuthentication(options => 
{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
				.AddJwtBearer(jwt=>
				{
								var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection(key:"JwtConfig:Secret")
												.Value);
								jwt.SaveToken = true;
								jwt.TokenValidationParameters = new TokenValidationParameters()
								{
												ValidateIssuerSigningKey = true,
												IssuerSigningKey = new SymmetricSecurityKey(key),
												ValidateIssuer = false,//for developemnt only
												ValidateAudience = false,
												RequireExpirationTime = false,// for dev needs to be updated when refresh token is added
												ValidateLifetime= true

								};


				});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedEmail = false)
												.AddEntityFrameworkStores<AppDbContext>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
				app.UseSwagger();
				app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
