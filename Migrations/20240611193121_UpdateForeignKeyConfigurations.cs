using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conferences_projet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeyConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Entreprises_EntrepriseId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Entreprises_EntrepriseId1",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Universites_UniversiteId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Universites_UniversiteId1",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_EntrepriseId1",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_UniversiteId1",
                table: "users");

            migrationBuilder.DropColumn(
                name: "EntrepriseId1",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UniversiteId1",
                table: "users");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Entreprises_EntrepriseId",
                table: "users",
                column: "EntrepriseId",
                principalTable: "Entreprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Universites_UniversiteId",
                table: "users",
                column: "UniversiteId",
                principalTable: "Universites",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Entreprises_EntrepriseId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Universites_UniversiteId",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "EntrepriseId1",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UniversiteId1",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_EntrepriseId1",
                table: "users",
                column: "EntrepriseId1");

            migrationBuilder.CreateIndex(
                name: "IX_users_UniversiteId1",
                table: "users",
                column: "UniversiteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Entreprises_EntrepriseId",
                table: "users",
                column: "EntrepriseId",
                principalTable: "Entreprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Entreprises_EntrepriseId1",
                table: "users",
                column: "EntrepriseId1",
                principalTable: "Entreprises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Universites_UniversiteId",
                table: "users",
                column: "UniversiteId",
                principalTable: "Universites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Universites_UniversiteId1",
                table: "users",
                column: "UniversiteId1",
                principalTable: "Universites",
                principalColumn: "Id");
        }
    }
}
