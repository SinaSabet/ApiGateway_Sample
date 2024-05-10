using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGateway.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "apigatewayservices");

            migrationBuilder.CreateTable(
                name: "BaseEntity",
                schema: "apigatewayservices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "apigatewayservices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DownstreamPathTemplate = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DownstreamScheme = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpstreamPathTemplate = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UpstreamHttpMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_BaseEntity_Id",
                        column: x => x.Id,
                        principalSchema: "apigatewayservices",
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services",
                schema: "apigatewayservices");

            migrationBuilder.DropTable(
                name: "BaseEntity",
                schema: "apigatewayservices");
        }
    }
}
