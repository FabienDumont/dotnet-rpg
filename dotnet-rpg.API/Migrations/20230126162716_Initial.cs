using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnetrpg.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Damage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    HitPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    Intelligence = table.Column<int>(type: "INTEGER", nullable: false),
                    Class = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fights = table.Column<int>(type: "INTEGER", nullable: false),
                    Victories = table.Column<int>(type: "INTEGER", nullable: false),
                    Defeats = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkill",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkill", x => new { x.CharactersId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CharacterSkill_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Damage = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[,]
                {
                    { 1, 30, "Fireball" },
                    { 2, 20, "Frenzy" },
                    { 3, 50, "Blizzard" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[,]
                {
                    { 1, new byte[] { 176, 104, 247, 201, 224, 83, 68, 208, 121, 91, 189, 24, 131, 239, 217, 170, 48, 193, 152, 113, 60, 158, 84, 95, 97, 245, 156, 34, 109, 48, 237, 150, 180, 163, 155, 189, 101, 9, 82, 123, 135, 114, 64, 113, 252, 164, 14, 80, 77, 35, 60, 216, 110, 174, 157, 63, 102, 99, 91, 185, 147, 62, 208, 96 }, new byte[] { 249, 30, 112, 192, 213, 252, 4, 178, 20, 33, 152, 164, 204, 127, 47, 218, 20, 180, 147, 243, 235, 31, 32, 33, 57, 157, 121, 18, 208, 254, 175, 9, 4, 112, 17, 180, 87, 17, 228, 50, 235, 20, 134, 187, 93, 9, 109, 133, 83, 148, 50, 174, 130, 161, 201, 12, 39, 239, 96, 156, 195, 230, 92, 89, 179, 58, 120, 73, 91, 117, 200, 115, 43, 75, 94, 233, 124, 70, 203, 50, 76, 83, 121, 221, 173, 253, 152, 53, 229, 181, 1, 103, 123, 166, 187, 236, 169, 173, 127, 152, 221, 240, 250, 184, 139, 85, 188, 223, 142, 135, 107, 115, 103, 179, 114, 241, 64, 188, 111, 46, 160, 202, 210, 76, 105, 88, 125, 249 }, "Admin" },
                    { 2, new byte[] { 176, 104, 247, 201, 224, 83, 68, 208, 121, 91, 189, 24, 131, 239, 217, 170, 48, 193, 152, 113, 60, 158, 84, 95, 97, 245, 156, 34, 109, 48, 237, 150, 180, 163, 155, 189, 101, 9, 82, 123, 135, 114, 64, 113, 252, 164, 14, 80, 77, 35, 60, 216, 110, 174, 157, 63, 102, 99, 91, 185, 147, 62, 208, 96 }, new byte[] { 249, 30, 112, 192, 213, 252, 4, 178, 20, 33, 152, 164, 204, 127, 47, 218, 20, 180, 147, 243, 235, 31, 32, 33, 57, 157, 121, 18, 208, 254, 175, 9, 4, 112, 17, 180, 87, 17, 228, 50, 235, 20, 134, 187, 93, 9, 109, 133, 83, 148, 50, 174, 130, 161, 201, 12, 39, 239, 96, 156, 195, 230, 92, 89, 179, 58, 120, 73, 91, 117, 200, 115, 43, 75, 94, 233, 124, 70, 203, 50, 76, 83, 121, 221, 173, 253, 152, 53, 229, 181, 1, 103, 123, 166, 187, 236, 169, 173, 127, 152, 221, 240, 250, 184, 139, 85, 188, 223, 142, 135, 107, 115, 103, 179, 114, 241, 64, 188, 111, 46, 160, 202, 210, 76, 105, 88, 125, 249 }, "Joueur1" },
                    { 3, new byte[] { 176, 104, 247, 201, 224, 83, 68, 208, 121, 91, 189, 24, 131, 239, 217, 170, 48, 193, 152, 113, 60, 158, 84, 95, 97, 245, 156, 34, 109, 48, 237, 150, 180, 163, 155, 189, 101, 9, 82, 123, 135, 114, 64, 113, 252, 164, 14, 80, 77, 35, 60, 216, 110, 174, 157, 63, 102, 99, 91, 185, 147, 62, 208, 96 }, new byte[] { 249, 30, 112, 192, 213, 252, 4, 178, 20, 33, 152, 164, 204, 127, 47, 218, 20, 180, 147, 243, 235, 31, 32, 33, 57, 157, 121, 18, 208, 254, 175, 9, 4, 112, 17, 180, 87, 17, 228, 50, 235, 20, 134, 187, 93, 9, 109, 133, 83, 148, 50, 174, 130, 161, 201, 12, 39, 239, 96, 156, 195, 230, 92, 89, 179, 58, 120, 73, 91, 117, 200, 115, 43, 75, 94, 233, 124, 70, 203, 50, 76, 83, 121, 221, 173, 253, 152, 53, 229, 181, 1, 103, 123, 166, 187, 236, 169, 173, 127, 152, 221, 240, 250, 184, 139, 85, 188, 223, 142, 135, 107, 115, 103, 179, 114, 241, 64, 188, 111, 46, 160, 202, 210, 76, 105, 88, 125, 249 }, "Joueur2" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[,]
                {
                    { 1, 1, 0, 10, 0, 100, 10, "Lancelot", 15, 2, 0 },
                    { 2, 3, 0, 10, 0, 100, 15, "Gandalf", 10, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "CharacterSkill",
                columns: new[] { "CharactersId", "SkillsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[,]
                {
                    { 1, 1, 20, "The Master Sword" },
                    { 2, 2, 5, "Crystal Wand" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkill_SkillsId",
                table: "CharacterSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSkill");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
