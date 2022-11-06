using MeuLivroDeReceitas.Domain.Extensions;
using MeuLivroDeReceitas.Infrastructure;
using MeuLivroDeReceitas.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

CreateDatabase();

app.Run();

void CreateDatabase()
{
    var connection = builder.Configuration.GetDatabase();
    var database = builder.Configuration.GetSection("Database:Name").Value;

    Database.CreateDatabase(connection, database);

    app.Migrate();
}
