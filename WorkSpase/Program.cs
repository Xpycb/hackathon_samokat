using Microsoft.EntityFrameworkCore;
using WorkSpase.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ParkingZoneConext>(opt =>
    opt.UseInMemoryDatabase("Place"));
builder.Services.AddDbContext<WorkingPlacesConext>(opt =>
    opt.UseInMemoryDatabase("Place"));
builder.Services.AddDbContext<MeetingZoneConext>(opt =>
    opt.UseInMemoryDatabase("Place"));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
