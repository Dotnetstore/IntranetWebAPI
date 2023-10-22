using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
namespace Infrastructure.Migrations
{
    [ExcludeFromCodeCoverage]
    /// <inheritdoc />
    public partial class v100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Contact");

            migrationBuilder.EnsureSchema(
                name: "Organization");

            migrationBuilder.CreateTable(
                name: "ContactInformation",
                schema: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ContactInformationType = table.Column<Guid>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastUpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsGdpr = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastUpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsGdpr = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnCompany",
                schema: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastUpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsGdpr = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CorporateId = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastUpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsGdpr = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastUpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsGdpr = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastNameFirst = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMale = table.Column<bool>(type: "INTEGER", nullable: false),
                    SocialSecurityNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    Salt1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Salt2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Salt3 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Salt4 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IsBlocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    BlockedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LastLoginDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_OwnCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Organization",
                        principalTable: "OwnCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleInGroup",
                schema: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastUpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsGdpr = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleInGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleInGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Organization",
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleInGroup_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Organization",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInGroup",
                schema: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastUpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsGdpr = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Organization",
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInGroup_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Organization",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInRole",
                schema: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastUpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsGdpr = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Organization",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Organization",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_Text",
                schema: "Contact",
                table: "ContactInformation",
                column: "Text");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Name",
                schema: "Organization",
                table: "Group",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                schema: "Organization",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleInGroup_GroupId",
                schema: "Organization",
                table: "RoleInGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleInGroup_RoleId",
                schema: "Organization",
                table: "RoleInGroup",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                schema: "Organization",
                table: "User",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInGroup_GroupId",
                schema: "Organization",
                table: "UserInGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInGroup_UserId",
                schema: "Organization",
                table: "UserInGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRole_RoleId",
                schema: "Organization",
                table: "UserInRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRole_UserId",
                schema: "Organization",
                table: "UserInRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInformation",
                schema: "Contact");

            migrationBuilder.DropTable(
                name: "RoleInGroup",
                schema: "Organization");

            migrationBuilder.DropTable(
                name: "UserInGroup",
                schema: "Organization");

            migrationBuilder.DropTable(
                name: "UserInRole",
                schema: "Organization");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "Organization");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Organization");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Organization");

            migrationBuilder.DropTable(
                name: "OwnCompany",
                schema: "Organization");
        }
    }
}
