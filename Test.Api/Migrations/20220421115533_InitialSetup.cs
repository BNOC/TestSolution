using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Api.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sheds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boxes_Sheds_ShedId",
                        column: x => x.ShedId,
                        principalTable: "Sheds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Things",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Things", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Things_Boxes_BoxId",
                        column: x => x.BoxId,
                        principalTable: "Boxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sheds",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Brown Shed" });

            migrationBuilder.InsertData(
                table: "Boxes",
                columns: new[] { "Id", "Name", "ShedId" },
                values: new object[] { 1, "Box 1", 1 });

            migrationBuilder.InsertData(
                table: "Things",
                columns: new[] { "Id", "BoxId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Spanner" },
                    { 2, 1, "Wrench" },
                    { 3, 1, "Screwdriver" },
                    { 4, 1, "Socket" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_ShedId",
                table: "Boxes",
                column: "ShedId");

            migrationBuilder.CreateIndex(
                name: "IX_Things_BoxId",
                table: "Things",
                column: "BoxId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Things");

            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "Sheds");
        }
    }
}
