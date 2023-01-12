using System.Security.Claims;
using Artisanal.Web;
using Artisanal.Web.Services;
using Artisanal.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ProductService>();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<AuthService>();



builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("../KEYS"))
    .SetApplicationName("MyApp");

builder.Services.AddAuthentication()
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,o=>{
            o.LoginPath = "/Auth/Login";
            
        });

builder.Services.AddAuthorization(options =>{
    options.AddPolicy("AdminOnly",p=>{
        p.RequireRole("admin").RequireAuthenticatedUser();
    });

    
});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
