using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiDDD.Data.Migrations
{
    public partial class StatesCitiesAndAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e9225260-ab53-44d1-aba4-2bacc9e75555"));

            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "User",
                newName: "UpdatedAt");

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ShortName = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    IBGECode = table.Column<int>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    Street = table.Column<string>(maxLength: 60, nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: false),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CreatedAt", "Name", "ShortName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(944), "Acre", "AC", null },
                    { new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1168), "São Paulo", "SP", null },
                    { new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1164), "Sergipe", "SE", null },
                    { new Guid("b81f95e0-f226-4afd-9763-290001637ed4"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1161), "Santa Catarina", "SC", null },
                    { new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1157), "Rio Grande do Sul", "RS", null },
                    { new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1154), "Roraima", "RR", null },
                    { new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1152), "Rondônia", "RO", null },
                    { new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1148), "Rio Grande do Norte", "RN", null },
                    { new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1145), "Rio de Janeiro", "RJ", null },
                    { new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1140), "Paraná", "PR", null },
                    { new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1137), "Piauí", "PI", null },
                    { new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1134), "Pernambuco", "PE", null },
                    { new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1131), "Paraíba", "PB", null },
                    { new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1128), "Pará", "PA", null },
                    { new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1125), "Mato Grosso", "MT", null },
                    { new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1121), "Mato Grosso do Sul", "MS", null },
                    { new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1117), "Minas Gerais", "MG", null },
                    { new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1114), "Maranhão", "MA", null },
                    { new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1111), "Goiás", "GO", null },
                    { new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1108), "Espírito Santo", "ES", null },
                    { new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1104), "Distrito Federal", "DF", null },
                    { new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1102), "Ceará", "CE", null },
                    { new Guid("5abca453-d035-4766-a81b-9f73d683a54b"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1099), "Bahia", "BA", null },
                    { new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1080), "Amapá", "AP", null },
                    { new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1076), "Amazonas", "AM", null },
                    { new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1068), "Alagoas", "AL", null },
                    { new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"), new DateTime(2020, 9, 3, 21, 44, 47, 356, DateTimeKind.Local).AddTicks(1172), "Tocantins", "TO", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "UpdatedAt" },
                values: new object[] { new Guid("1cb193c5-4fd6-4e64-a054-1c21ff6c5460"), new DateTime(2020, 9, 3, 21, 44, 47, 217, DateTimeKind.Local).AddTicks(8455), "admin@mail.com", "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ZipCode",
                table: "Addresses",
                column: "ZipCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IBGECode",
                table: "Cities",
                column: "IBGECode");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_ShortName",
                table: "States",
                column: "ShortName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1cb193c5-4fd6-4e64-a054-1c21ff6c5460"));

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "User",
                newName: "updatedAt");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "updatedAt" },
                values: new object[] { new Guid("e9225260-ab53-44d1-aba4-2bacc9e75555"), new DateTime(2020, 8, 24, 21, 30, 26, 359, DateTimeKind.Local).AddTicks(7544), "admin@mail.com", "Admin", null });
        }
    }
}
