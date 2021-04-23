using Microsoft.EntityFrameworkCore.Migrations;

namespace Shooting.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chamber",
                columns: table => new
                {
                    ChamberID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChamberName = table.Column<string>(type: "TEXT", nullable: false),
                    Wiki = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamber", x => x.ChamberID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturerName = table.Column<string>(type: "TEXT", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: true),
                    Wiki = table.Column<string>(type: "TEXT", nullable: true),
                    WebSite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "LoadData",
                columns: table => new
                {
                    LoadID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoadName = table.Column<string>(type: "TEXT", nullable: false),
                    Projectile = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectileWeight = table.Column<float>(type: "REAL", nullable: false),
                    Propellent = table.Column<string>(type: "TEXT", nullable: false),
                    PropellentWeight = table.Column<float>(type: "REAL", nullable: false),
                    Primer = table.Column<string>(type: "TEXT", nullable: false),
                    ChamberID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadData", x => x.LoadID);
                    table.ForeignKey(
                        name: "FK_LoadData_Chamber_ChamberID",
                        column: x => x.ChamberID,
                        principalTable: "Chamber",
                        principalColumn: "ChamberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Firearm",
                columns: table => new
                {
                    FirearmID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirearmName = table.Column<string>(type: "TEXT", nullable: false),
                    Wiki = table.Column<string>(type: "TEXT", nullable: true),
                    LeftSide = table.Column<string>(type: "TEXT", nullable: true),
                    RightSide = table.Column<string>(type: "TEXT", nullable: true),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ManufacturerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firearm", x => x.FirearmID);
                    table.ForeignKey(
                        name: "FK_Firearm_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ManufacturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamberFirearm",
                columns: table => new
                {
                    ChambersChamberID = table.Column<int>(type: "INTEGER", nullable: false),
                    FirearmsFirearmID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamberFirearm", x => new { x.ChambersChamberID, x.FirearmsFirearmID });
                    table.ForeignKey(
                        name: "FK_ChamberFirearm_Chamber_ChambersChamberID",
                        column: x => x.ChambersChamberID,
                        principalTable: "Chamber",
                        principalColumn: "ChamberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChamberFirearm_Firearm_FirearmsFirearmID",
                        column: x => x.FirearmsFirearmID,
                        principalTable: "Firearm",
                        principalColumn: "FirearmID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChamberFirearm_FirearmsFirearmID",
                table: "ChamberFirearm",
                column: "FirearmsFirearmID");

            migrationBuilder.CreateIndex(
                name: "IX_Firearm_ManufacturerID",
                table: "Firearm",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_LoadData_ChamberID",
                table: "LoadData",
                column: "ChamberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamberFirearm");

            migrationBuilder.DropTable(
                name: "LoadData");

            migrationBuilder.DropTable(
                name: "Firearm");

            migrationBuilder.DropTable(
                name: "Chamber");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
