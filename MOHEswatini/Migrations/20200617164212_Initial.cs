using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOHEswatini.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_DiseaseSurveillance",
                columns: table => new
                {
                    iID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dArrivalDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    cArrivedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    cVehicleNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    cPointOfEntry = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cSeatNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    cName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cContactNo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    cPassportNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    cAge = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    cGender = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    cRecentlyVisitedCountry1 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    cNoOfDaysSpend1 = table.Column<int>(type: "int", nullable: true),
                    cRecentlyVisitedCountry2 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    cNoOfDaysSpend2 = table.Column<int>(type: "int", nullable: true),
                    cRecentlyVisitedCountry3 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    cNoOfDaysSpend3 = table.Column<int>(type: "int", nullable: true),
                    cRecentlyVisitedCountry4 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    cNoOfDaysSpend4 = table.Column<int>(type: "int", nullable: true),
                    cPhysicalAddress = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    cPhysicalContactNo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    cCountryOfResidence = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    lHeadache = table.Column<bool>(type: "bit", nullable: true),
                    lBleeding = table.Column<bool>(type: "bit", nullable: true),
                    lFever = table.Column<bool>(type: "bit", nullable: true),
                    lCough = table.Column<bool>(type: "bit", nullable: true),
                    lGeneralBodyPain = table.Column<bool>(type: "bit", nullable: true),
                    lDiarrhea = table.Column<bool>(type: "bit", nullable: true),
                    lVomiting = table.Column<bool>(type: "bit", nullable: true),
                    lSoreThroat = table.Column<bool>(type: "bit", nullable: true),
                    lPolio = table.Column<bool>(type: "bit", nullable: true),
                    lYellowFever = table.Column<bool>(type: "bit", nullable: true),
                    lMalaria = table.Column<bool>(type: "bit", nullable: true),
                    lOthers = table.Column<bool>(type: "bit", nullable: true),
                    cOthersVaccine = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    cHealthFacility = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    lCovidTested = table.Column<bool>(type: "bit", nullable: true),
                    dCovidTestingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    cCovidTestingLab = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    cCovidTestingKitNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    cCovidTestResult = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    cCreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    dCreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    cUpdatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    dUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_DiseaseSurveillance", x => x.iID);
                });

            //migrationBuilder.CreateTable(
            //    name: "U_Users",
            //    columns: table => new
            //    {
            //        cUserID = table.Column<string>(maxLength: 50, nullable: false),
            //        cPassword = table.Column<string>(maxLength: 50, nullable: false),
            //        cName = table.Column<string>(maxLength: 50, nullable: true),
            //        cUserType = table.Column<string>(maxLength: 20, nullable: true),
            //        cContactNo = table.Column<string>(maxLength: 13, nullable: true),
            //        cEmailID = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_U_Users", x => x.cUserID);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_DiseaseSurveillance");

            migrationBuilder.DropTable(
                name: "U_Users");
        }
    }
}
