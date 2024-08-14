using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemInfo.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddClientSystemInfoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientSystemInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CpuProcess = table.Column<double>(type: "float", nullable: false),
                    RamProcess = table.Column<double>(type: "float", nullable: false),
                    NumbersSum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSystemInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientSystemInfos");
        }
    }
}
