using Microsoft.Extensions.FileProviders;
using Trips.API.Extensions;
using Trips.API.Middlewares;
using Trips.API.Profiles;
using Trips.Infrastructure;

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

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "images")),
    RequestPath = "/images"
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

app.Run();