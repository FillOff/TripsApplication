using Trips.API.Middlewares;
using Trips.API.Profiles;
using Trips.Application;
using Trips.Infrastructure;
using Trips.Infrastructure.Services;
using Trips.Interfaces.Auth;
using Trips.Persistence;
using Trips.Persistence.Databases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(
    typeof(TripProfile), 
    typeof(RouteProfile), 
    typeof(CommentProfile));
builder.Services.AddOptions<JwtOptions>()
    .Bind(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();