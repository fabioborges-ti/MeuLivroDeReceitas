using FluentMigrator;

namespace MeuLivroDeReceitas.Infrastructure.Migrations.Version;

[Migration(version: 1, description: "Cria tabela usuario")]
public class Version1 : Migration
{
    public override void Down()
    {
        throw new NotImplementedException();
    }

    public override void Up()
    {
        var table = Create.Table("user");

        Base.CreateBaseTable(table);

        _ = table
            .WithColumn("name").AsString(120).NotNullable()
            .WithColumn("phone").AsString(20).NotNullable()
            .WithColumn("email").AsString(100).NotNullable()
            .WithColumn("password").AsString(2000).NotNullable();
    }
}
