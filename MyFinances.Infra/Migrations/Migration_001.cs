using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances.Infra.Migrations
{
    [Migration(001)]
    public class Migration_001 : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt16().PrimaryKey().NotNullable().Identity()
                .WithColumn("Nome").AsString()
                .WithColumn("Email").AsString()
                .WithColumn("Senha").AsString()
                .WithColumn("TipoUsuario").AsInt16()
                .WithColumn("DataAtualizacao").AsDateTime().WithDefaultValue(DateTime.Now);

            Create.Index("idx_tipo_usuario").OnTable("User").OnColumn("TipoUsuario");

            


            /*
             CREATE TABLE `user` (
  `Id` int(4) NOT NULL AUTO_INCREMENT,
  `Codigo` smallint(6) NOT NULL,
  `Nome` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Senha` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `TipoUsuario` smallint(6) NOT NULL,
  `DataAtualizacao` datetime NOT NULL DEFAULT '2020-04-11 22:03:35',
  PRIMARY KEY (`Id`),
  KEY `idx_tipo_usuario` (`TipoUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
             */

            //Create.Table("ClienteEndereco")
            //    .WithColumn("Id").AsString(50).PrimaryKey().NotNullable()
            //    .WithColumn("ClienteId").AsString(20).NotNullable()
            //    .WithColumn("Cep").AsString()
            //    .WithColumn("Estado").AsString()
            //    .WithColumn("Cidade").AsString()
            //    .WithColumn("Bairro").AsString()
            //    .WithColumn("Rua").AsString()
            //    .WithColumn("Numero").AsString()
            //    .WithColumn("Complemento").AsString()
            //    .WithColumn("Observacao").AsString()
            //    .WithColumn("DataAtualizacao").AsDateTime().WithDefaultValue(DateTime.Now)
            //    .WithColumn("DataFinalizacao").AsDateTime().Nullable();

            //Create.ForeignKey("fk_cliente_endereco_id_cliente_cliente_id")
            //    .FromTable("ClienteEndereco").ForeignColumn("ClienteId")
            //    .ToTable("Cliente").PrimaryColumn("Id")
            //    .OnDeleteOrUpdate(System.Data.Rule.Cascade);

            //Create.Table("ClienteTelefone")
            //    .WithColumn("Id").AsString(50).PrimaryKey().NotNullable()
            //    .WithColumn("ClienteId").AsString(20).NotNullable()
            //    .WithColumn("Ddd").AsString()
            //    .WithColumn("Numero").AsString()
            //    .WithColumn("Observacao").AsString()
            //    .WithColumn("DataAtualizacao").AsDateTime().WithDefaultValue(DateTime.Now)
            //    .WithColumn("DataFinalizacao").AsDateTime().Nullable();

            //Create.ForeignKey("fk_cliente_telefone_id_cliente_cliente_id")
            //    .FromTable("ClienteTelefone").ForeignColumn("ClienteId")
            //    .ToTable("Cliente").PrimaryColumn("Id")
            //    .OnDeleteOrUpdate(System.Data.Rule.Cascade);

            //Create.Table("ClienteEmail")
            //    .WithColumn("Id").AsString(50).PrimaryKey().NotNullable()
            //    .WithColumn("ClienteId").AsString(20).NotNullable()
            //    .WithColumn("Descricao").AsString()
            //    .WithColumn("DataAtualizacao").AsDateTime().WithDefaultValue(DateTime.Now)
            //    .WithColumn("DataFinalizacao").AsDateTime().Nullable();

            //Create.ForeignKey("fk_cliente_email_id_cliente_cliente_id")
            //    .FromTable("ClienteEmail").ForeignColumn("ClienteId")
            //    .ToTable("Cliente").PrimaryColumn("Id")
            //    .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("User");
        }
    }
}
