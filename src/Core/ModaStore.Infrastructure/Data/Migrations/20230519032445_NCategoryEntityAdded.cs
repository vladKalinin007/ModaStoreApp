using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class NCategoryEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryLayoutId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageSize = table.Column<int>(type: "int", nullable: true),
                    AllowCustomersToSelectPageSize = table.Column<bool>(type: "bit", nullable: true),
                    PageSizeOptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowOnHomePage = table.Column<bool>(type: "bit", nullable: true),
                    FeaturedProductsOnHomePage = table.Column<bool>(type: "bit", nullable: true),
                    ShowOnSearchBox = table.Column<bool>(type: "bit", nullable: true),
                    SearchBoxDisplayOrder = table.Column<int>(type: "int", nullable: true),
                    IncludeInMenu = table.Column<bool>(type: "bit", nullable: true),
                    LimitedToGroups = table.Column<bool>(type: "bit", nullable: true),
                    LimitedToStores = table.Column<bool>(type: "bit", nullable: true),
                    SeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagStyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultSort = table.Column<int>(type: "int", nullable: true),
                    HideOnCatalog = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserField",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewCategories");

            migrationBuilder.DropTable(
                name: "UserField");
        }
    }
}
