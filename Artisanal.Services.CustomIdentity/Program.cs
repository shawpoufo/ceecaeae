using Artisanal.Services.CustomIdentity.DbContexts;
using Artisanal.Services.CustomIdentity.Models.DAO;
using Artisanal.Services.CustomIdentity.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddTransient<LoginRepository>();
builder.Services.AddTransient<PasswordHasher<LoginDAO>>();
builder.Services.AddTransient<PwdHash>();
builder.Services.AddDbContext<ApplicationDbContext>(options=>
 options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// builder.Services.AddHttpClient();
// builder.Services.AddHttpContextAccessor();

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("../KEYS"))
    .SetApplicationName("MyApp");

builder.Services.AddAuthentication()
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
