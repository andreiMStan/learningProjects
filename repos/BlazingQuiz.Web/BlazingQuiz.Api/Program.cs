using BlazingQuiz.Api.Data;
using BlazingQuiz.Api.Data.Entities;
using BlazingQuiz.Api.Endpoints;
using BlazingQuiz.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

 var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
    var connectionString = builder.Configuration.GetConnectionString("Quiz");



builder.Services.AddDbContext<QuizContext>(options =>
{
    options.UseSqlServer(connectionString);
}, optionsLifetime: ServiceLifetime.Singleton);

builder.Services.AddDbContextFactory<QuizContext>(options =>
{
    options.UseSqlServer(connectionString);

});

// singleton can not be injected in scope

// another option define optionsLifeTime:ServiceLifetime.Singleton)

//}

//builder.Services.AddSingleton<Func<QuizContext>>(sp => () =>
//{
//    var scope = sp.CreateScope();
//    return scope.ServiceProvider.GetRequiredService<QuizContext>();
//});
////authentication 
builder.Services.AddAuthentication(
    options =>
    {
        options
    .DefaultAuthenticateScheme =
    JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
.AddJwtBearer(
options =>
{
        var secretKey = builder.Configuration.GetValue<string>("Jwt:Secret");//get from appsettings
        var symetricKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey=symetricKey,
            ValidIssuer = builder.Configuration.GetValue<string>("Jwt:Issuer"),
            ValidAudience= builder.Configuration.GetValue<string>("Jwt:Audience"),
            ValidateIssuer=true,
            ValidateAudience= true,
            ValidateIssuerSigningKey= true,
        };
    
}) ;
builder.Services.AddAuthorization();
//in case can not access api because of corse policy , check in console development tools
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p =>
    {
        var allowedOriginsStr = builder.Configuration.GetValue<string>("AllowedOrigins");

        var allowedOrigins = allowedOriginsStr.Split(',', StringSplitOptions.TrimEntries
            | StringSplitOptions.RemoveEmptyEntries);

        p.WithOrigins(allowedOrigins)
    .AllowAnyHeader()
    .AllowAnyMethod();
    });
   
});

builder.Services.AddTransient<AuthService>()
    .AddTransient<CategoryService>() 
    .AddTransient<QuizService>()
    .AddTransient<AdminService>()
    .AddTransient<StudentQuizService>()
    ; 


var app = builder.Build();

#if DEBUG
ApplyDbMigration(app.Services);
#endif
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication()
    .UseAuthorization();

app.MapAuthEndpoints()
    .MapCategoryEndpoint()
    .MapQuizEnpoint()
    .MapAdminEndpoints()
    .MapStudentQuizEndpoints()
    ;

app.Run();

static void ApplyDbMigration(IServiceProvider sp)
{
    var scope = sp.CreateScope();
    var context=scope.ServiceProvider.GetRequiredService<QuizContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}