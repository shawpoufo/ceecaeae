var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 
}


// app.UseHttpsRedirection();

// app.UseAuthorization();
app.MapReverseProxy();
// app.MapControllers();

app.Run();
