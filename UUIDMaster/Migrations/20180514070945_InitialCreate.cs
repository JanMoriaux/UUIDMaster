using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UUIDMaster.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "uuid_activities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    EventUUID = table.Column<string>(type: "varchar(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    UUID = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uuid_activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "uuid_events",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    UUID = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uuid_events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "uuid_reservations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActivityUUID = table.Column<string>(type: "varchar(36)", nullable: false),
                    UUID = table.Column<string>(type: "varchar(36)", nullable: false),
                    UserUUID = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uuid_reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "uuid_users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    UUID = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uuid_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_uuid_activities_UUID",
                table: "uuid_activities",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uuid_activities_Name_EventUUID",
                table: "uuid_activities",
                columns: new[] { "Name", "EventUUID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uuid_events_Name",
                table: "uuid_events",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uuid_events_UUID",
                table: "uuid_events",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uuid_reservations_UUID",
                table: "uuid_reservations",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uuid_reservations_ActivityUUID_UserUUID",
                table: "uuid_reservations",
                columns: new[] { "ActivityUUID", "UserUUID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uuid_users_Email",
                table: "uuid_users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uuid_users_UUID",
                table: "uuid_users",
                column: "UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uuid_activities");

            migrationBuilder.DropTable(
                name: "uuid_events");

            migrationBuilder.DropTable(
                name: "uuid_reservations");

            migrationBuilder.DropTable(
                name: "uuid_users");
        }
    }
}
