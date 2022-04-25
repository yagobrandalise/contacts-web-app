using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsApplication.Migrations
{
    public partial class pictureContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PictureContent",
                table: "People",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureContent",
                table: "People");
        }
    }
}
