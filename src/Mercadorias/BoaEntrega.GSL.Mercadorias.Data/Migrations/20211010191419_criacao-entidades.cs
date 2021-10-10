using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoaEntrega.GSL.Mercadorias.Data.Migrations
{
    public partial class criacaoentidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depositos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(nullable: false),
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    Endereco_CEP = table.Column<string>(nullable: true),
                    Endereco_Rua = table.Column<string>(nullable: true),
                    Endereco_Numero = table.Column<int>(nullable: true),
                    Endereco_Bairro = table.Column<string>(nullable: true),
                    Endereco_Cidade = table.Column<string>(nullable: true),
                    Endereco_UF = table.Column<string>(nullable: true),
                    Endereco_Complemento = table.Column<string>(nullable: true),
                    CapacidadeMaxima = table.Column<float>(nullable: false),
                    CapacidadeAlocada = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mercadorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(nullable: false),
                    CodigoRastreamento = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    EnderecoEntrega_CEP = table.Column<string>(nullable: true),
                    EnderecoEntrega_Rua = table.Column<string>(nullable: true),
                    EnderecoEntrega_Numero = table.Column<int>(nullable: true),
                    EnderecoEntrega_Bairro = table.Column<string>(nullable: true),
                    EnderecoEntrega_Cidade = table.Column<string>(nullable: true),
                    EnderecoEntrega_UF = table.Column<string>(nullable: true),
                    EnderecoEntrega_Complemento = table.Column<string>(nullable: true),
                    Peso = table.Column<float>(nullable: false),
                    Valor = table.Column<float>(nullable: false),
                    DataEntrega = table.Column<DateTimeOffset>(nullable: false),
                    DepositoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercadorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mercadorias_Depositos_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "Depositos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_DepositoId",
                table: "Mercadorias",
                column: "DepositoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mercadorias");

            migrationBuilder.DropTable(
                name: "Depositos");
        }
    }
}
