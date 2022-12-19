using Order.Application.Mapper;
using Order.Domain.Interfaces.Repositories.DataConnector;
using Order.Extensions;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("default");

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Core));
builder.Services.AddControllers();

builder.Services.AddScoped<IDbConnector>(db => new Order.Infra.DataConnector.MySqlConnector(connectionString));
builder.RegisterIoc();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.SwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.RoutePrefix = "swagger";
        setup.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
