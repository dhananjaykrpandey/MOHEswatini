using Microsoft.EntityFrameworkCore.Migrations;

namespace MOHEswatini.Migrations
{
    public partial class MOHEswatiniMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "U_Users",
                columns: table => new
                {
                    cUserID = table.Column<string>(maxLength: 50, nullable: false),
                    cPassword = table.Column<string>(maxLength: 50, nullable: false),
                    cName = table.Column<string>(maxLength: 50, nullable: true),
                    cUserType = table.Column<string>(maxLength: 20, nullable: true),
                    cContactNo = table.Column<string>(maxLength: 13, nullable: true),
                    cEmailID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_U_Users", x => x.cUserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "U_Users");
        }
    }
}
