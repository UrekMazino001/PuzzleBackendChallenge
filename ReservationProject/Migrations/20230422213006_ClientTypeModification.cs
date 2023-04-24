using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationProject.Migrations
{
    /// <inheritdoc />
    public partial class ClientTypeModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "chkClientClientType",
                table: "Clients");

            migrationBuilder.AddCheckConstraint(
                name: "chkClientClientType",
                table: "Clients",
                sql: "ClientType in ('P', 'C')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "chkClientClientType",
                table: "Clients");

            migrationBuilder.AddCheckConstraint(
                name: "chkClientClientType",
                table: "Clients",
                sql: "status in ('P', 'C')");
        }
    }
}
