using OnlineShop.CartService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastrucutre(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();