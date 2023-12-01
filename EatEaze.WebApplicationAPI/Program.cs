using EatEazeServices.Interfaces;
using EatEazeServices.Implementations;
using EatEaze.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using EatEaze.Services.Implementations;
using EatEaze.DbHelpers;
using EatEaze.Data.Repositiories.RepositoriesImpls;
using System.Text.Json.Serialization;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using AutoMapper;
using EatEaze.WebApplicationAPI.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EatEazeDataContext>(options =>
    options.UseNpgsql(connectionString)
);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IPositionsRepository, PositionsRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoriesRepository>();
builder.Services.AddScoped<IRestarauntsRepository, RestarauntsRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IPositionsService, PositionsService>();
builder.Services.AddScoped<IRestarauntsService, RestarauntsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
