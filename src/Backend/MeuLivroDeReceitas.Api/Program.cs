using MeuLivroDeReceitas.Domain.Extensions;
using MeuLivroDeReceitas.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

    Database.CreateDatabase(connection, "receitas_db");
}
