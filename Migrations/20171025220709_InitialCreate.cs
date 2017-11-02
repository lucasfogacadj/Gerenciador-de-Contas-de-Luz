using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MvcDemo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataDeLeitura = table.Column<string>(type: "TEXT", nullable: false),
                    DataDoPagamento = table.Column<string>(type: "TEXT", nullable: false),
                    KwGasto = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaDeConsumo = table.Column<float>(type: "REAL", nullable: false),
                    NumLeitura = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorPagar = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
