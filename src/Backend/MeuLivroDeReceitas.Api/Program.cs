using MeuLivroDeReceitas.Domain.Extensions;
using MeuLivroDeReceitas.Infrastructure;
using MeuLivroDeReceitas.Infrastructure.Migrations;
using MeuLivroDeReceitas.Infrastructure.Migrations.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

CriarDatabase();

app.Run();

void CriarDatabase()
{
    var connection = builder.Configuration.GetConnection();
    var database = builder.Configuration.GetDatabase();

    Database.CriarDatabase(connection, database);

    app.MigrarDatabase();
}
