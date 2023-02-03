using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = "Host=127.0.0.1;Database=festivals;Username=postgres;Password=19112001";
// Replace 'YourDbContext' with the name of your own DbContext derived class.
builder.Services.AddDbContext<FestivalDbContext>(opt => opt.UseNpgsql(connectionString)

);

// var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
// builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var festivalMapGroup = app.MapGroup("/api/festivals");
var festivalEndpoints = new FestivalEndpoints();
festivalEndpoints.Configure(festivalMapGroup);


var artistMapGroup = app.MapGroup("/api/artists");
var artistEndpoints = new ArtistEndpoints();
artistEndpoints.Configure(artistMapGroup);







app.Run();
