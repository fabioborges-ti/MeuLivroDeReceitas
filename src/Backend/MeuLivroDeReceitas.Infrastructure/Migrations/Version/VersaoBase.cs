using FluentMigrator.Builders.Create.Table;

namespace MeuLivroDeReceitas.Infrastructure.Migrations.Version;

public static class VersaoBase
{
    public static ICreateTableColumnOptionOrWithColumnSyntax AdicionarColunasComuns(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
    {
        return table.WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("DataCriacao").AsDateTime().NotNullable();
    }
}
