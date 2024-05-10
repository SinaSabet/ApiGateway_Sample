using ApiGateway.Application.Extensions;
using ApiGateway.Infrastructure;
using ApiGateway.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiGatewayContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext"),
                builder => builder.MigrationsAssembly(typeof(ApiGatewayContext).Assembly.FullName)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.RegisterInfrastructureServices().RegisterApplicationServices(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        corsbuilder =>
        {
            corsbuilder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthorization();

app.MapControllers();




app.Run();


