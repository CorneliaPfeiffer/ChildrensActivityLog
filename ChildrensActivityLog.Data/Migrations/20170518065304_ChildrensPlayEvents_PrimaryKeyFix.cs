using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChildrensActivityLog.Data.Migrations
{
    public partial class ChildrensPlayEvents_PrimaryKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildrensPlayEvents",
                table: "ChildrensPlayEvents");

            migrationBuilder.DropIndex(
                name: "IX_ChildrensPlayEvents_ChildId",
                table: "ChildrensPlayEvents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ChildrensPlayEvents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildrensPlayEvents",
                table: "ChildrensPlayEvents",
                columns: new[] { "ChildId", "PlayEventId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildrensPlayEvents",
                table: "ChildrensPlayEvents");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ChildrensPlayEvents",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildrensPlayEvents",
                table: "ChildrensPlayEvents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChildrensPlayEvents_ChildId",
                table: "ChildrensPlayEvents",
                column: "ChildId");
        }
    }
}
