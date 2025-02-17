using Trips.API.Extensions;
using Trips.API.Middlewares;
using Trips.API.Profiles;
using Trips.Infrastructure;

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

builder.Services.AddDbContexts();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddExternalServices();

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