using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeStore.Data.Migrations
{
    public partial class deletesexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Sexes_SexId",
                table: "Shoes");

            migrationBuilder.DropTable(
                name: "Sexes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_SexId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "SexId",
                table: "Shoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SexId",
                table: "Shoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_SexId",
                table: "Shoes",
                column: "SexId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Sexes_SexId",
                table: "Shoes",
                column: "SexId",
                principalTable: "Sexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
