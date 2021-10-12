using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoaEntrega.GSL.Cadastros.Data.Migrations
{
    public partial class AdicionadoDataCriacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataCriacao",
                table: "Fornecedores",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Complemento",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataCriacao",
                table: "Clientes",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Complemento",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Endereco_Complemento",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Endereco_Complemento",
                table: "Clientes");
        }
    }
}
