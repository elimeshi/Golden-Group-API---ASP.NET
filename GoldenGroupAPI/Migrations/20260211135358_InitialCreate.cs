using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGroupAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_buyer_requests_clients_client_id",
                table: "buyer_requests");

            migrationBuilder.DropForeignKey(
                name: "fk_housing_units_listings_listing_id",
                table: "housing_units");

            migrationBuilder.DropForeignKey(
                name: "fk_listings_clients_client_id",
                table: "listings");

            migrationBuilder.DropPrimaryKey(
                name: "pk_listings",
                table: "listings");

            migrationBuilder.DropPrimaryKey(
                name: "pk_housing_units",
                table: "housing_units");

            migrationBuilder.DropPrimaryKey(
                name: "pk_clients",
                table: "clients");

            migrationBuilder.DropPrimaryKey(
                name: "pk_buyer_requests",
                table: "buyer_requests");

            migrationBuilder.RenameTable(
                name: "listings",
                newName: "listing");

            migrationBuilder.RenameTable(
                name: "housing_units",
                newName: "housing_unit");

            migrationBuilder.RenameTable(
                name: "clients",
                newName: "client");

            migrationBuilder.RenameTable(
                name: "buyer_requests",
                newName: "buyer_request");

            migrationBuilder.RenameIndex(
                name: "ix_listings_client_id",
                table: "listing",
                newName: "IX_listing_client_id");

            migrationBuilder.RenameIndex(
                name: "ix_housing_units_listing_id",
                table: "housing_unit",
                newName: "ix_housing_unit_listing_id");

            migrationBuilder.RenameIndex(
                name: "ix_buyer_requests_client_id",
                table: "buyer_request",
                newName: "IX_buyer_request_client_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_listing",
                table: "listing",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_housing_unit",
                table: "housing_unit",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_client",
                table: "client",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_buyer_request",
                table: "buyer_request",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_buyer_request_client_client_id",
                table: "buyer_request",
                column: "client_id",
                principalTable: "client",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_housing_unit_listing_listing_id",
                table: "housing_unit",
                column: "listing_id",
                principalTable: "listing",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_listing_client_client_id",
                table: "listing",
                column: "client_id",
                principalTable: "client",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_buyer_request_client_client_id",
                table: "buyer_request");

            migrationBuilder.DropForeignKey(
                name: "fk_housing_unit_listing_listing_id",
                table: "housing_unit");

            migrationBuilder.DropForeignKey(
                name: "fk_listing_client_client_id",
                table: "listing");

            migrationBuilder.DropPrimaryKey(
                name: "pk_listing",
                table: "listing");

            migrationBuilder.DropPrimaryKey(
                name: "pk_housing_unit",
                table: "housing_unit");

            migrationBuilder.DropPrimaryKey(
                name: "pk_client",
                table: "client");

            migrationBuilder.DropPrimaryKey(
                name: "pk_buyer_request",
                table: "buyer_request");

            migrationBuilder.RenameTable(
                name: "listing",
                newName: "listings");

            migrationBuilder.RenameTable(
                name: "housing_unit",
                newName: "housing_units");

            migrationBuilder.RenameTable(
                name: "client",
                newName: "clients");

            migrationBuilder.RenameTable(
                name: "buyer_request",
                newName: "buyer_requests");

            migrationBuilder.RenameIndex(
                name: "IX_listing_client_id",
                table: "listings",
                newName: "ix_listings_client_id");

            migrationBuilder.RenameIndex(
                name: "ix_housing_unit_listing_id",
                table: "housing_units",
                newName: "ix_housing_units_listing_id");

            migrationBuilder.RenameIndex(
                name: "IX_buyer_request_client_id",
                table: "buyer_requests",
                newName: "ix_buyer_requests_client_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_listings",
                table: "listings",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_housing_units",
                table: "housing_units",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_clients",
                table: "clients",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_buyer_requests",
                table: "buyer_requests",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_buyer_requests_clients_client_id",
                table: "buyer_requests",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_housing_units_listings_listing_id",
                table: "housing_units",
                column: "listing_id",
                principalTable: "listings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_listings_clients_client_id",
                table: "listings",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
