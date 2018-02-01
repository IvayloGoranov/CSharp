using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fruits.Web.IdentityData.Migrations
{
    public partial class SubscriptionsAddedIndexOnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Name",
                table: "Subscriptions",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_Name",
                table: "Subscriptions");
        }
    }
}
