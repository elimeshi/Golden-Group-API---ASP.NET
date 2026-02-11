using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoldenGroupAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialSupabaseMigrationSnakeCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    id_number = table.Column<string>(type: "text", nullable: false),
                    phone_numbers = table.Column<List<string>>(type: "text[]", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "buyer_requests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    zones = table.Column<int[]>(type: "integer[]", nullable: false),
                    min_floor = table.Column<int>(type: "integer", nullable: false),
                    max_floor = table.Column<int>(type: "integer", nullable: false),
                    max_price = table.Column<decimal>(type: "numeric", nullable: false),
                    min_size = table.Column<double>(type: "double precision", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    liquidity = table.Column<int>(type: "integer", nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    request_type = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    max_equity = table.Column<decimal>(type: "numeric", nullable: true),
                    community = table.Column<int>(type: "integer", nullable: true),
                    registration_type = table.Column<int>(type: "integer", nullable: true),
                    max_partners = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_buyer_requests", x => x.id);
                    table.ForeignKey(
                        name: "fk_buyer_requests_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "listings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city = table.Column<string>(type: "text", nullable: false),
                    street = table.Column<string>(type: "text", nullable: false),
                    building_number = table.Column<string>(type: "text", nullable: false),
                    apt_number = table.Column<string>(type: "text", nullable: false),
                    floor = table.Column<int>(type: "integer", nullable: false),
                    rooms = table.Column<double>(type: "double precision", nullable: false),
                    squared_meters = table.Column<double>(type: "double precision", nullable: false),
                    zone = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    entering_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    application_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    property_state = table.Column<int>(type: "integer", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    listing_type = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    registration_type = table.Column<int>(type: "integer", nullable: true),
                    num_of_partners = table.Column<int>(type: "integer", nullable: true),
                    required_equity = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_listings", x => x.id);
                    table.ForeignKey(
                        name: "fk_listings_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "housing_units",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    squared_meters = table.Column<double>(type: "double precision", nullable: false),
                    rooms = table.Column<double>(type: "double precision", nullable: false),
                    floor = table.Column<int>(type: "integer", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    listing_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_housing_units", x => x.id);
                    table.ForeignKey(
                        name: "fk_housing_units_listings_listing_id",
                        column: x => x.listing_id,
                        principalTable: "listings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_buyer_requests_client_id",
                table: "buyer_requests",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_housing_units_listing_id",
                table: "housing_units",
                column: "listing_id");

            migrationBuilder.CreateIndex(
                name: "ix_listings_client_id",
                table: "listings",
                column: "client_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buyer_requests");

            migrationBuilder.DropTable(
                name: "housing_units");

            migrationBuilder.DropTable(
                name: "listings");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
