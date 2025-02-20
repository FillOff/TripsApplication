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
    typeof(ImageProfile));

builder.Services.AddApiAuthentication(builder.Configuration);
builder.Services.AddDbContexts();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddExternalServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader() 
              .AllowAnyMethod(); 
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "wwwroot/images")),
    RequestPath = "/wwwroot/images"
});

app.UseAuthentication();
app.UseAuthorization();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.MapControllers();

app.UseCors("AllowAllOrigins");

app.Run();