using FluentMigrator;

namespace ProJur.Domain.Infra.Migrations
{
    [Migration(1807202101)]
    public class Migration_18072021_AddTableUsuario : Migration
    {
        public Migration_18072021_AddTableUsuario()
        {
        }

        public override void Down()
        {
           
        }

        public override void Up()
        {
           Create.Table("Usuario")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
           .WithColumn("Nome").AsCustom("varchar(100)").NotNullable()
           .WithColumn("Sobrenome").AsCustom("varchar(160)").NotNullable()
           .WithColumn("Email").AsCustom("varchar(160)").NotNullable()
           .WithColumn("DataNascimento").AsDateTime().NotNullable()
           .WithColumn("Escolaridade").AsInt32().NotNullable();
        }
    }
}