using Microsoft.EntityFrameworkCore.Migrations;

namespace APILabb4.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    HobbyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HobbyName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "PersonHobbies",
                columns: table => new
                {
                    PersonHobbyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HobbyId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    WebLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHobbies", x => x.PersonHobbyId);
                    table.ForeignKey(
                        name: "FK_PersonHobbies_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonHobbies_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "HobbyId", "Description", "HobbyName" },
                values: new object[,]
                {
                    { 1, "Drawing, painting, sculpting, crafts, DIY", "Art" },
                    { 2, "Ballsports, swimming, martial arts, jogging, dancing", "Sports" },
                    { 3, "Cooking food, baking", "Cooking" },
                    { 4, "Singing, playing instruments, production", "Music" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Address", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Skånegatan 17", "lolo@hot.com", "Lina", "Haytham", "0761121112" },
                    { 2, "Kvarnängsgatan 24", "jojo@hot.com", "Jones", "Haytham", "0735454123" },
                    { 3, "Kungsgatan 5", "nata@hot.com", "Natalia", "Al", "0707654321" }
                });

            migrationBuilder.InsertData(
                table: "PersonHobbies",
                columns: new[] { "PersonHobbyId", "HobbyId", "PersonId", "WebLink" },
                values: new object[,]
                {
                    { 1, 3, 1, "www.recepten.se/" },
                    { 2, 3, 1, "www.koket.se/" },
                    { 3, 2, 2, "www.bet365.com/" },
                    { 4, 3, 2, "www.koket.se/" },
                    { 5, 1, 3, "diysweden.se" },
                    { 6, 4, 3, "soundcloud.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbies_HobbyId",
                table: "PersonHobbies",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbies_PersonId",
                table: "PersonHobbies",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonHobbies");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
