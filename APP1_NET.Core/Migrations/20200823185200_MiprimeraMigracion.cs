using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APP1_NET.Core.Migrations
{
    public partial class MiprimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cat");

            migrationBuilder.CreateTable(
                name: "Categoria",
                schema: "Cat",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    ImagenMiniatura = table.Column<Guid>(nullable: false),
                    ImagenBanner = table.Column<Guid>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    UsuarioCreo = table.Column<Guid>(nullable: false),
                    FechaModifico = table.Column<DateTime>(nullable: false),
                    UsuarioModifico = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                schema: "Cat",
                columns: table => new
                {
                    IdMarca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Logo = table.Column<Guid>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    UsuarioCreo = table.Column<Guid>(nullable: false),
                    FechaModifico = table.Column<DateTime>(nullable: false),
                    UsuarioModifico = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.IdMarca);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria",
                schema: "Cat");

            migrationBuilder.DropTable(
                name: "Marca",
                schema: "Cat");
        }
    }
}
