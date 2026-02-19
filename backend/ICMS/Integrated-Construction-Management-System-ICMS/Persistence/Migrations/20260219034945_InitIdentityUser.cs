using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrated_Construction_Management_System_ICMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantBoqs_Projects_ProjectID",
                table: "ConsultantBoqs");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerBoqs_Projects_ProjectID",
                table: "EngineerBoqs");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerInvoices_Projects_ProjectID",
                table: "EngineerInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_FormanTasks_Projects_ProjectID",
                table: "FormanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralDrowings_Projects_ProjectID",
                table: "GeneralDrowings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContracts_Projects_ProjectID",
                table: "ProjectContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Foremen_ForemanId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_MainClient_MainClientID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_MainConsultants_mainConsultanttMaincosultantID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectManagers_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSiteEngineers_Projects_ProjectID",
                table: "ProjectSiteEngineers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSubConsultants_Projects_ProjectID",
                table: "ProjectSubConsultants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSubContractors_Projects_ProjectID",
                table: "ProjectSubContractors");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopDrawings_Projects_ProjectID",
                table: "ShopDrawings");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Projects_ProjectID",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_SubConstractorInvoices_Projects_ProjectID",
                table: "SubConstractorInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "projects");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "projects",
                newName: "IX_projects_ProjectManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_mainConsultanttMaincosultantID",
                table: "projects",
                newName: "IX_projects_mainConsultanttMaincosultantID");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_MainClientID",
                table: "projects",
                newName: "IX_projects_MainClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ForemanId",
                table: "projects",
                newName: "IX_projects_ForemanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projects",
                table: "projects",
                column: "ProjectID");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Jobtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantBoqs_projects_ProjectID",
                table: "ConsultantBoqs",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerBoqs_projects_ProjectID",
                table: "EngineerBoqs",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerInvoices_projects_ProjectID",
                table: "EngineerInvoices",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_FormanTasks_projects_ProjectID",
                table: "FormanTasks",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralDrowings_projects_ProjectID",
                table: "GeneralDrowings",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContracts_projects_ProjectID",
                table: "ProjectContracts",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_Foremen_ForemanId",
                table: "projects",
                column: "ForemanId",
                principalTable: "Foremen",
                principalColumn: "ForemanId");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_MainClient_MainClientID",
                table: "projects",
                column: "MainClientID",
                principalTable: "MainClient",
                principalColumn: "MainClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_MainConsultants_mainConsultanttMaincosultantID",
                table: "projects",
                column: "mainConsultanttMaincosultantID",
                principalTable: "MainConsultants",
                principalColumn: "MaincosultantID");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_ProjectManagers_ProjectManagerId",
                table: "projects",
                column: "ProjectManagerId",
                principalTable: "ProjectManagers",
                principalColumn: "ProjectManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSiteEngineers_projects_ProjectID",
                table: "ProjectSiteEngineers",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSubConsultants_projects_ProjectID",
                table: "ProjectSubConsultants",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSubContractors_projects_ProjectID",
                table: "ProjectSubContractors",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopDrawings_projects_ProjectID",
                table: "ShopDrawings",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_projects_ProjectID",
                table: "Stores",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubConstractorInvoices_projects_ProjectID",
                table: "SubConstractorInvoices",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantBoqs_projects_ProjectID",
                table: "ConsultantBoqs");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerBoqs_projects_ProjectID",
                table: "EngineerBoqs");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerInvoices_projects_ProjectID",
                table: "EngineerInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_FormanTasks_projects_ProjectID",
                table: "FormanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralDrowings_projects_ProjectID",
                table: "GeneralDrowings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContracts_projects_ProjectID",
                table: "ProjectContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_Foremen_ForemanId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_MainClient_MainClientID",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_MainConsultants_mainConsultanttMaincosultantID",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_ProjectManagers_ProjectManagerId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSiteEngineers_projects_ProjectID",
                table: "ProjectSiteEngineers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSubConsultants_projects_ProjectID",
                table: "ProjectSubConsultants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSubContractors_projects_ProjectID",
                table: "ProjectSubContractors");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopDrawings_projects_ProjectID",
                table: "ShopDrawings");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_projects_ProjectID",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_SubConstractorInvoices_projects_ProjectID",
                table: "SubConstractorInvoices");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projects",
                table: "projects");

            migrationBuilder.RenameTable(
                name: "projects",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_projects_ProjectManagerId",
                table: "Projects",
                newName: "IX_Projects_ProjectManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_projects_mainConsultanttMaincosultantID",
                table: "Projects",
                newName: "IX_Projects_mainConsultanttMaincosultantID");

            migrationBuilder.RenameIndex(
                name: "IX_projects_MainClientID",
                table: "Projects",
                newName: "IX_Projects_MainClientID");

            migrationBuilder.RenameIndex(
                name: "IX_projects_ForemanId",
                table: "Projects",
                newName: "IX_Projects_ForemanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantBoqs_Projects_ProjectID",
                table: "ConsultantBoqs",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerBoqs_Projects_ProjectID",
                table: "EngineerBoqs",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerInvoices_Projects_ProjectID",
                table: "EngineerInvoices",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_FormanTasks_Projects_ProjectID",
                table: "FormanTasks",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralDrowings_Projects_ProjectID",
                table: "GeneralDrowings",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContracts_Projects_ProjectID",
                table: "ProjectContracts",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Foremen_ForemanId",
                table: "Projects",
                column: "ForemanId",
                principalTable: "Foremen",
                principalColumn: "ForemanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_MainClient_MainClientID",
                table: "Projects",
                column: "MainClientID",
                principalTable: "MainClient",
                principalColumn: "MainClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_MainConsultants_mainConsultanttMaincosultantID",
                table: "Projects",
                column: "mainConsultanttMaincosultantID",
                principalTable: "MainConsultants",
                principalColumn: "MaincosultantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectManagers_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId",
                principalTable: "ProjectManagers",
                principalColumn: "ProjectManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSiteEngineers_Projects_ProjectID",
                table: "ProjectSiteEngineers",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSubConsultants_Projects_ProjectID",
                table: "ProjectSubConsultants",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSubContractors_Projects_ProjectID",
                table: "ProjectSubContractors",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopDrawings_Projects_ProjectID",
                table: "ShopDrawings",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Projects_ProjectID",
                table: "Stores",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubConstractorInvoices_Projects_ProjectID",
                table: "SubConstractorInvoices",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");
        }
    }
}
