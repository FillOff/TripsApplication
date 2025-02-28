using Microsoft.Extensions.FileProviders;
using Trips.API.Extensions;
using Trips.API.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(
    typeof(TripProfile), 
    typeof(RouteProfile), 
    typeof(CommentProfile),
    typeof(ImageProfile),
    typeof(UserProfile));

builder.Services.AddApiAuthentication(builder.Configuration);
builder.Services.AddDbContexts();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddExternalServices();

var app = builder.Build();

app.UseCors(options => {
    options.WithHeaders().AllowAnyHeader();
    options.WithOrigins().AllowAnyOrigin();
    options.WithMethods().AllowAnyMethod();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "wwwroot/images")),
    RequestPath = "/images"
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();