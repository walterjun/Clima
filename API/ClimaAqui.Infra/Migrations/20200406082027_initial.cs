using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimaAqui.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    all = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    lat = table.Column<double>(nullable: false),
                    lon = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Main",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    temp = table.Column<double>(nullable: false),
                    feels_like = table.Column<double>(nullable: false),
                    temp_min = table.Column<double>(nullable: false),
                    temp_max = table.Column<double>(nullable: false),
                    pressure = table.Column<int>(nullable: false),
                    sea_level = table.Column<int>(nullable: false),
                    grnd_level = table.Column<int>(nullable: false),
                    humidity = table.Column<int>(nullable: false),
                    temp_kf = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    __invalid_name__3h = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    pod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    speed = table.Column<double>(nullable: false),
                    deg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wind", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    name = table.Column<string>(nullable: true),
                    coordId = table.Column<int>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    population = table.Column<int>(nullable: false),
                    timezone = table.Column<int>(nullable: false),
                    sunrise = table.Column<int>(nullable: false),
                    sunset = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Coord_coordId",
                        column: x => x.coordId,
                        principalTable: "Coord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    cod = table.Column<string>(nullable: true),
                    message = table.Column<int>(nullable: false),
                    cnt = table.Column<int>(nullable: false),
                    cityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_City_cityId",
                        column: x => x.cityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    dt = table.Column<int>(nullable: false),
                    mainId = table.Column<int>(nullable: true),
                    cloudsId = table.Column<int>(nullable: true),
                    windId = table.Column<int>(nullable: true),
                    sysId = table.Column<int>(nullable: true),
                    dt_txt = table.Column<string>(nullable: true),
                    rainId = table.Column<int>(nullable: true),
                    ConsultaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.Id);
                    table.ForeignKey(
                        name: "FK_List_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_List_Clouds_cloudsId",
                        column: x => x.cloudsId,
                        principalTable: "Clouds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_List_Main_mainId",
                        column: x => x.mainId,
                        principalTable: "Main",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_List_Rain_rainId",
                        column: x => x.rainId,
                        principalTable: "Rain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_List_Sys_sysId",
                        column: x => x.sysId,
                        principalTable: "Sys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_List_Wind_windId",
                        column: x => x.windId,
                        principalTable: "Wind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    main = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    ListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_List_ListId",
                        column: x => x.ListId,
                        principalTable: "List",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_coordId",
                table: "City",
                column: "coordId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_cityId",
                table: "Consulta",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_List_ConsultaId",
                table: "List",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_List_cloudsId",
                table: "List",
                column: "cloudsId");

            migrationBuilder.CreateIndex(
                name: "IX_List_mainId",
                table: "List",
                column: "mainId");

            migrationBuilder.CreateIndex(
                name: "IX_List_rainId",
                table: "List",
                column: "rainId");

            migrationBuilder.CreateIndex(
                name: "IX_List_sysId",
                table: "List",
                column: "sysId");

            migrationBuilder.CreateIndex(
                name: "IX_List_windId",
                table: "List",
                column: "windId");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_ListId",
                table: "Weather",
                column: "ListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DropTable(
                name: "Main");

            migrationBuilder.DropTable(
                name: "Rain");

            migrationBuilder.DropTable(
                name: "Sys");

            migrationBuilder.DropTable(
                name: "Wind");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Coord");
        }
    }
}
