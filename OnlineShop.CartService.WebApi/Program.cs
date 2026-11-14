using OnlineShop.CartService.Application;
using OnlineShop.CartService.Infrastructure;
using OnlineShop.CartService.WebApi.ExceptionHandling;
using OnlineShop.CartService.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastrucutre(builder.Configuration);

builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseExceptionHandler();
app.UseSwaggerDocumentation(app.Environment);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();