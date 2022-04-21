using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Test.Api.Data;
using Test.Api.Repositories;
using Test.Api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<TestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDb"))
);

builder.Services.AddScoped<IShedRepository, ShedRepository>();
builder.Services.AddScoped<IBoxRepository, BoxRepository>();
builder.Services.AddScoped<IThingRepository, ThingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Allow use
app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7277", "https://localhost:7277")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
