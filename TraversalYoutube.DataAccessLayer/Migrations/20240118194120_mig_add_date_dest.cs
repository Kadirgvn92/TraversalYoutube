﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalYoutube.DataAccessLayer.Migrations
{
    public partial class mig_add_date_dest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Destinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Destinations");
        }
    }
}