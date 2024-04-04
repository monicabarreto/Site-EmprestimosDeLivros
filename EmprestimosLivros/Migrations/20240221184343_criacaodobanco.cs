﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimosLivros.Migrations
{
    public partial class criacaodobanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmprestarLivros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recebedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivroEmprestado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmprestarLivros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmprestarLivros");
        }
    }
}
