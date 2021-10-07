using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BoaEntrega.GSL.Cadastros.Data.Migrations
{
    public partial class iniciadobd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    Endereco_CEP = table.Column<string>(nullable: true),
                    Endereco_Rua = table.Column<string>(nullable: true),
                    Endereco_Numero = table.Column<int>(nullable: true),
                    Endereco_Bairro = table.Column<string>(nullable: true),
                    Endereco_Cidade = table.Column<string>(nullable: true),
                    Endereco_UF = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: false),
                    Endereco_CEP = table.Column<string>(nullable: true),
                    Endereco_Rua = table.Column<string>(nullable: true),
                    Endereco_Numero = table.Column<int>(nullable: true),
                    Endereco_Bairro = table.Column<string>(nullable: true),
                    Endereco_Cidade = table.Column<string>(nullable: true),
                    Endereco_UF = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
