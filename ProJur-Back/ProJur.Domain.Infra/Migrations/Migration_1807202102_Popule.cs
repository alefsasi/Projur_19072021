using System;
using FluentMigrator;

namespace ProJur.Domain.Infra.Migrations
{
    [Migration(1807202102)]
    public class Migration_1807202102 : Migration
    {
        public Migration_1807202102()
        {
        }

        public override void Down()
        {
           
        }

        public override void Up()
        {
            Insert.IntoTable("usuario").Row(new { Nome = "Aleff", Sobrenome = "Santos", Email = "email1.generico@gmail.com", DataNascimento = DateTime.Now, Escolaridade = 3 });
              Insert.IntoTable("usuario").Row(new { Nome = "Joao", Sobrenome = "Santos", Email = "email2.generico@gmail.com", DataNascimento = DateTime.Now, Escolaridade = 2 });
                Insert.IntoTable("usuario").Row(new { Nome = "Mauricio", Sobrenome = "Santos", Email = "email3.generico@gmail.com", DataNascimento = DateTime.Now, Escolaridade = 2 });
                  Insert.IntoTable("usuario").Row(new { Nome = "Bruno", Sobrenome = "Santos", Email = "email4.generico@gmail.com", DataNascimento = DateTime.Now, Escolaridade = 3 });
        }
    }
}