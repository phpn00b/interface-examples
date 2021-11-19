using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
	public partial class First : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Clients",
				columns: table => new
				{
					ClientId = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					FirstName = table.Column<string>(type: "TEXT", nullable: true),
					LastName = table.Column<string>(type: "TEXT", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Clients", x => x.ClientId);
				});

			migrationBuilder.CreateTable(
				name: "Addresses",
				columns: table => new
				{
					AddressId = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					ClientId = table.Column<int>(type: "INTEGER", nullable: false),
					Line1 = table.Column<string>(type: "TEXT", nullable: true),
					Line2 = table.Column<string>(type: "TEXT", nullable: true),
					City = table.Column<string>(type: "TEXT", nullable: true),
					State = table.Column<string>(type: "TEXT", nullable: true),
					Country = table.Column<string>(type: "TEXT", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Addresses", x => x.AddressId);
					table.ForeignKey(
						name: "FK_Addresses_Clients_ClientId",
						column: x => x.ClientId,
						principalTable: "Clients",
						principalColumn: "ClientId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "PhoneNumbers",
				columns: table => new
				{
					PhoneNumberId = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					ClientId = table.Column<int>(type: "INTEGER", nullable: false),
					Location = table.Column<string>(type: "TEXT", nullable: true),
					Number = table.Column<string>(type: "TEXT", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PhoneNumbers", x => x.PhoneNumberId);
					table.ForeignKey(
						name: "FK_PhoneNumbers_Clients_ClientId",
						column: x => x.ClientId,
						principalTable: "Clients",
						principalColumn: "ClientId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Addresses_ClientId",
				table: "Addresses",
				column: "ClientId");

			migrationBuilder.CreateIndex(
				name: "IX_PhoneNumbers_ClientId",
				table: "PhoneNumbers",
				column: "ClientId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Addresses");

			migrationBuilder.DropTable(
				name: "PhoneNumbers");

			migrationBuilder.DropTable(
				name: "Clients");
		}
	}
}
