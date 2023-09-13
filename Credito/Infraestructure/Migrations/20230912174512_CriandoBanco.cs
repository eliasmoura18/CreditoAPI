using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ddd = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    datainsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataalteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataexclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "financiamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idcliente = table.Column<int>(type: "int", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    tipofinanciamento = table.Column<int>(type: "int", nullable: false),
                    valortotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dataultimovencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datainsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataalteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataexclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financiamento", x => x.id);
                    table.ForeignKey(
                        name: "FK_financiamento_cliente_idcliente",
                        column: x => x.idcliente,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parcela",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idfinanciamento = table.Column<int>(type: "int", nullable: false),
                    numeroparcela = table.Column<int>(type: "int", nullable: false),
                    valorparcela = table.Column<decimal>(type: "decimal(18,2)", maxLength: 11, nullable: false),
                    datavencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datapagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    datainsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataalteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataexclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parcela", x => x.id);
                    table.ForeignKey(
                        name: "FK_parcela_financiamento_idfinanciamento",
                        column: x => x.idfinanciamento,
                        principalTable: "financiamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "id", "cpf", "celular", "ddd", "dataalteracao", "dataexclusao", "datainsercao", "nome", "uf" },
                values: new object[,]
                {
                    { 1, "58672118006", "912345678", "62", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 15, 16, 30, 12, 0, DateTimeKind.Unspecified), "Elias de Moura", "GO" },
                    { 2, "76249229086", "943218765", "11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 15, 45, 33, 0, DateTimeKind.Unspecified), "João da silva", "SP" },
                    { 3, "16162984052", "911223344", "31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 11, 9, 11, 26, 0, DateTimeKind.Unspecified), "Fulano de Tal", "MG" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_financiamento_idcliente",
                table: "financiamento",
                column: "idcliente");

            migrationBuilder.CreateIndex(
                name: "IX_parcela_idfinanciamento",
                table: "parcela",
                column: "idfinanciamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parcela");

            migrationBuilder.DropTable(
                name: "financiamento");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
