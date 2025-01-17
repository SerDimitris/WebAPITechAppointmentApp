using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechAppointmentApp.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentTableAddedFixedv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Technicians_TechnicianId",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Technicians_TechnicianId",
                table: "Appointments",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Technicians_TechnicianId",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Technicians_TechnicianId",
                table: "Appointments",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
