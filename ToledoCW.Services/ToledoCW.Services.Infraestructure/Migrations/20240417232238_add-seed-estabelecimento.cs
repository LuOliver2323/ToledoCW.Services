﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToledoCW.Services.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class addseedestabelecimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "estabelecimento",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2L, "Estabelecimento 2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "estabelecimento",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
