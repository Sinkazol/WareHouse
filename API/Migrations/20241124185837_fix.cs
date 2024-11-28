using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Felhasznalok_Szerepek_RoleId",
                table: "Felhasznalok");

            migrationBuilder.DropForeignKey(
                name: "FK_Keszlet_Aruk_ProductId",
                table: "Keszlet");

            migrationBuilder.DropForeignKey(
                name: "FK_Keszlet_Telephelyek_WarehouseId",
                table: "Keszlet");

            migrationBuilder.DropForeignKey(
                name: "FK_Mozgatas_Aruk_ProductId",
                table: "Mozgatas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mozgatas_Telephelyek_DestinationId",
                table: "Mozgatas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mozgatas_Telephelyek_SourceId",
                table: "Mozgatas");

            migrationBuilder.AddForeignKey(
                name: "FK_Felhasznalok_Szerepek_RoleId",
                table: "Felhasznalok",
                column: "RoleId",
                principalTable: "Szerepek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Keszlet_Aruk_ProductId",
                table: "Keszlet",
                column: "ProductId",
                principalTable: "Aruk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Keszlet_Telephelyek_WarehouseId",
                table: "Keszlet",
                column: "WarehouseId",
                principalTable: "Telephelyek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mozgatas_Aruk_ProductId",
                table: "Mozgatas",
                column: "ProductId",
                principalTable: "Aruk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mozgatas_Telephelyek_DestinationId",
                table: "Mozgatas",
                column: "DestinationId",
                principalTable: "Telephelyek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mozgatas_Telephelyek_SourceId",
                table: "Mozgatas",
                column: "SourceId",
                principalTable: "Telephelyek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Felhasznalok_Szerepek_RoleId",
                table: "Felhasznalok");

            migrationBuilder.DropForeignKey(
                name: "FK_Keszlet_Aruk_ProductId",
                table: "Keszlet");

            migrationBuilder.DropForeignKey(
                name: "FK_Keszlet_Telephelyek_WarehouseId",
                table: "Keszlet");

            migrationBuilder.DropForeignKey(
                name: "FK_Mozgatas_Aruk_ProductId",
                table: "Mozgatas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mozgatas_Telephelyek_DestinationId",
                table: "Mozgatas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mozgatas_Telephelyek_SourceId",
                table: "Mozgatas");

            migrationBuilder.AddForeignKey(
                name: "FK_Felhasznalok_Szerepek_RoleId",
                table: "Felhasznalok",
                column: "RoleId",
                principalTable: "Szerepek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Keszlet_Aruk_ProductId",
                table: "Keszlet",
                column: "ProductId",
                principalTable: "Aruk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Keszlet_Telephelyek_WarehouseId",
                table: "Keszlet",
                column: "WarehouseId",
                principalTable: "Telephelyek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mozgatas_Aruk_ProductId",
                table: "Mozgatas",
                column: "ProductId",
                principalTable: "Aruk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mozgatas_Telephelyek_DestinationId",
                table: "Mozgatas",
                column: "DestinationId",
                principalTable: "Telephelyek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mozgatas_Telephelyek_SourceId",
                table: "Mozgatas",
                column: "SourceId",
                principalTable: "Telephelyek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
