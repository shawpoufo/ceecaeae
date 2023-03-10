using Artisanal.Services.ProductAPI;
using Artisanal.Services.ProductAPI.DbContexts;
using Artisanal.Services.ProductAPI.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options=>
 options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);










IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());













builder.Services.AddScoped<IProductRepository, ProductRepository>();





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("*");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
