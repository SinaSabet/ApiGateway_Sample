using ApiGateway.Application.Extensions;
using ApiGateway.Application.Query;
using ApiGateway.Infrastructure;
using ApiGateway.Infrastructure.Extensions;
using app.ApiGateWay.Extensions;
using app.ApiGateWay.Middleware;
using Microsoft.EntityFrameworkCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
                            .Build();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.RegisterApiGateway();
builder.Services.AddOcelot(configuration);

builder.Services.RegisterInfrastructureServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ApiGatewayContext>();
builder.Services.AddDbContext<ApiGatewayContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext"),
                builder => builder.MigrationsAssembly(typeof(ApiGatewayContext).Assembly.FullName)));
builder.Services.AddControllers();
builder.Services.AddScoped<IQueryService, QueryService>();
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
//app.UseMiddleware<FetchServicesMiddleware>();
app.UseMiddleware<CustomMideleware>();
app.UseOcelotBuildPipeline();
app.UseOcelot().Wait();

app.UseAuthorization();



app.Run();

