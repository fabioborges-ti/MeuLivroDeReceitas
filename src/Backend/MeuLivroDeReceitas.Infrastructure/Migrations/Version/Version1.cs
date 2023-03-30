using FluentMigrator;
using MeuLivroDeReceitas.Infrastructure.Migrations.Enums;

namespace MeuLivroDeReceitas.Infrastructure.Migrations.Version;

[Migration(version: (int)NumeroVersao.CriarTabelaUsuario, description: "Cria tabela usuario")]
public class Version1 : Migration
{
    public override void Up()
    {
        var table = Create.Table("Usuario");

        VersaoBase.AdicionarColunasComuns(table);

        table
            .WithColumn("Nome").AsString(100).NotNullable()
            .WithColumn("Email").AsString(100).NotNullable()
            .WithColumn("Senha").AsString(2000).NotNullable()
            .WithColumn("Telefone").AsString(14).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("user");
    }
}
