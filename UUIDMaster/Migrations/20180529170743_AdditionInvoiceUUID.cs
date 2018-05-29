using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UUIDMaster.Migrations
{
    public partial class AdditionInvoiceUUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "uuid_invoices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ReservationUUID = table.Column<string>(type: "varchar(36)", nullable: false),
                    UUID = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uuid_invoices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_uuid_invoices_ReservationUUID",
                table: "uuid_invoices",
                column: "ReservationUUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uuid_invoices_UUID",
                table: "uuid_invoices",
                column: "UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uuid_invoices");
        }
    }
}
