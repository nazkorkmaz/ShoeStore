using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeStore.Data.Migrations
{
    public partial class resimvecinsiyetekle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_sex_sexId",
                table: "Shoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sex",
                table: "sex");

            migrationBuilder.RenameTable(
                name: "sex",
                newName: "Sexes");

            migrationBuilder.RenameColumn(
                name: "sexId",
                table: "Shoes",
                newName: "SexId");

            migrationBuilder.RenameIndex(
                name: "IX_Shoes_sexId",
                table: "Shoes",
                newName: "IX_Shoes_SexId");

            migrationBuilder.AlterColumn<int>(
                name: "SexId",
                table: "Shoes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sexes",
                table: "Sexes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShoeImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    IsDefaultImage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoeImages_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeImages_ShoeId",
                table: "ShoeImages",
                column: "ShoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Sexes_SexId",
                table: "Shoes",
                column: "SexId",
                principalTable: "Sexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Sexes_SexId",
                table: "Shoes");

            migrationBuilder.DropTable(
                name: "ShoeImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sexes",
                table: "Sexes");

            migrationBuilder.RenameTable(
                name: "Sexes",
                newName: "sex");

            migrationBuilder.RenameColumn(
                name: "SexId",
                table: "Shoes",
                newName: "sexId");

            migrationBuilder.RenameIndex(
                name: "IX_Shoes_SexId",
                table: "Shoes",
                newName: "IX_Shoes_sexId");

            migrationBuilder.AlterColumn<int>(
                name: "sexId",
                table: "Shoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_sex",
                table: "sex",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_sex_sexId",
                table: "Shoes",
                column: "sexId",
                principalTable: "sex",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
