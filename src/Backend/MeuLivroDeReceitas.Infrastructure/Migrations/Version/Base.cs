using FluentMigrator.Builders.Create.Table;

namespace MeuLivroDeReceitas.Infrastructure.Migrations.Version;

public static class Base
{
    public static void CreateBaseTable(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
    {
        table
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("created_at").AsDateTime().NotNullable();
    }
}
