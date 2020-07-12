using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeStore.Data.Migrations
{
    public partial class yeide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sexId",
                table: "Shoes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "sex",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sex", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_sexId",
                table: "Shoes",
                column: "sexId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_sex_sexId",
                table: "Shoes",
                column: "sexId",
                principalTable: "sex",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_sex_sexId",
                table: "Shoes");

            migrationBuilder.DropTable(
                name: "sex");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_sexId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "sexId",
                table: "Shoes");
        }
    }
}
