using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrated_Construction_Management_System_ICMS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainClient",
                columns: table => new
                {
                    MainClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainClientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MainClientPhone = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    MainClientNationalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainClient", x => x.MainClientID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectManagers",
                columns: table => new
                {
                    ProjectManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectManagerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjectManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManagerPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectManagers", x => x.ProjectManagerId);
                });

            migrationBuilder.CreateTable(
                name: "SubContractors",
                columns: table => new
                {
                    SubContractorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubContractorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubContractorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubContractorPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SubContractorSpeciality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubContractors", x => x.SubContractorId);
                });

            migrationBuilder.CreateTable(
                name: "Foremen",
                columns: table => new
                {
                    ForemanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foremen", x => x.ForemanId);
                    table.ForeignKey(
                        name: "FK_Foremen_ProjectManagers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId");
                });

            migrationBuilder.CreateTable(
                name: "MainConsultants",
                columns: table => new
                {
                    MaincosultantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCosultantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainConsultants", x => x.MaincosultantID);
                    table.ForeignKey(
                        name: "FK_MainConsultants_ProjectManagers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId");
                });

            migrationBuilder.CreateTable(
                name: "SiteEngineer",
                columns: table => new
                {
                    SiteEngineerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteEngineerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SiteEngineerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteEngineerPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SiteEngineerSpeciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManagerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteEngineer", x => x.SiteEngineerId);
                    table.ForeignKey(
                        name: "FK_SiteEngineer_ProjectManagers_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjectLocation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProjectDescritpion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MainClientID = table.Column<int>(type: "int", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: false),
                    ForemanId = table.Column<int>(type: "int", nullable: false),
                    mainConsultanttMaincosultantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_Foremen_ForemanId",
                        column: x => x.ForemanId,
                        principalTable: "Foremen",
                        principalColumn: "ForemanId");
                    table.ForeignKey(
                        name: "FK_Projects_MainClient_MainClientID",
                        column: x => x.MainClientID,
                        principalTable: "MainClient",
                        principalColumn: "MainClientID");
                    table.ForeignKey(
                        name: "FK_Projects_MainConsultants_mainConsultanttMaincosultantID",
                        column: x => x.mainConsultanttMaincosultantID,
                        principalTable: "MainConsultants",
                        principalColumn: "MaincosultantID");
                    table.ForeignKey(
                        name: "FK_Projects_ProjectManagers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId");
                });

            migrationBuilder.CreateTable(
                name: "SubConsultant",
                columns: table => new
                {
                    SubCosultantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCosultantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManagerID = table.Column<int>(type: "int", nullable: false),
                    MainCosultantID = table.Column<int>(type: "int", nullable: false),
                    mainConsultantMaincosultantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubConsultant", x => x.SubCosultantID);
                    table.ForeignKey(
                        name: "FK_SubConsultant_MainConsultants_mainConsultantMaincosultantID",
                        column: x => x.mainConsultantMaincosultantID,
                        principalTable: "MainConsultants",
                        principalColumn: "MaincosultantID");
                    table.ForeignKey(
                        name: "FK_SubConsultant_ProjectManagers_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId");
                });

            migrationBuilder.CreateTable(
                name: "EngineerBoqs",
                columns: table => new
                {
                    EngineerBoqID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Unite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    StieEngineerId = table.Column<int>(type: "int", nullable: false),
                    SiteEngineerId = table.Column<int>(type: "int", nullable: true),
                    SubContractorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineerBoqs", x => x.EngineerBoqID);
                    table.ForeignKey(
                        name: "FK_EngineerBoqs_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_EngineerBoqs_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId");
                    table.ForeignKey(
                        name: "FK_EngineerBoqs_SubContractors_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractors",
                        principalColumn: "SubContractorId");
                });

            migrationBuilder.CreateTable(
                name: "FormanTasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    ForemanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormanTasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_FormanTasks_Foremen_ForemanId",
                        column: x => x.ForemanId,
                        principalTable: "Foremen",
                        principalColumn: "ForemanId");
                    table.ForeignKey(
                        name: "FK_FormanTasks_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                });

            migrationBuilder.CreateTable(
                name: "ProjectContracts",
                columns: table => new
                {
                    ProjectContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractDetails = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EndContractIfs = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    MainClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContracts", x => x.ProjectContractId);
                    table.ForeignKey(
                        name: "FK_ProjectContracts_MainClient_MainClientId",
                        column: x => x.MainClientId,
                        principalTable: "MainClient",
                        principalColumn: "MainClientID");
                    table.ForeignKey(
                        name: "FK_ProjectContracts_ProjectManagers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId");
                    table.ForeignKey(
                        name: "FK_ProjectContracts_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                });

            migrationBuilder.CreateTable(
                name: "ProjectSiteEngineers",
                columns: table => new
                {
                    ProjectSiteEngineerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    SiteEngineerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSiteEngineers", x => x.ProjectSiteEngineerID);
                    table.ForeignKey(
                        name: "FK_ProjectSiteEngineers_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_ProjectSiteEngineers_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId");
                });

            migrationBuilder.CreateTable(
                name: "ProjectSubContractors",
                columns: table => new
                {
                    ProjectSubContractorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    SubContractorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSubContractors", x => x.ProjectSubContractorId);
                    table.ForeignKey(
                        name: "FK_ProjectSubContractors_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_ProjectSubContractors_SubContractors_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractors",
                        principalColumn: "SubContractorId");
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    ForemanId = table.Column<int>(type: "int", nullable: false),
                    SiteEngineerId = table.Column<int>(type: "int", nullable: false),
                    SubContractorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreID);
                    table.ForeignKey(
                        name: "FK_Stores_Foremen_ForemanId",
                        column: x => x.ForemanId,
                        principalTable: "Foremen",
                        principalColumn: "ForemanId");
                    table.ForeignKey(
                        name: "FK_Stores_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_Stores_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId");
                    table.ForeignKey(
                        name: "FK_Stores_SubContractors_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractors",
                        principalColumn: "SubContractorId");
                });

            migrationBuilder.CreateTable(
                name: "SubConstractorInvoices",
                columns: table => new
                {
                    SubConstractorInvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Unite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    OldCompletion = table.Column<int>(type: "int", nullable: false),
                    NewCompletion = table.Column<int>(type: "int", nullable: false),
                    TotalInvoiceCost = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    SiteEngineerId = table.Column<int>(type: "int", nullable: false),
                    SubContractorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubConstractorInvoices", x => x.SubConstractorInvoiceId);
                    table.ForeignKey(
                        name: "FK_SubConstractorInvoices_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_SubConstractorInvoices_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId");
                    table.ForeignKey(
                        name: "FK_SubConstractorInvoices_SubContractors_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractors",
                        principalColumn: "SubContractorId");
                });

            migrationBuilder.CreateTable(
                name: "ConsultantBoqs",
                columns: table => new
                {
                    ConsultantBoqId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Unite = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    SubConsultantID = table.Column<int>(type: "int", nullable: false),
                    SiteEngineerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantBoqs", x => x.ConsultantBoqId);
                    table.ForeignKey(
                        name: "FK_ConsultantBoqs_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_ConsultantBoqs_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId");
                    table.ForeignKey(
                        name: "FK_ConsultantBoqs_SubConsultant_SubConsultantID",
                        column: x => x.SubConsultantID,
                        principalTable: "SubConsultant",
                        principalColumn: "SubCosultantID");
                });

            migrationBuilder.CreateTable(
                name: "EngineerInvoices",
                columns: table => new
                {
                    EngineerInvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Unite = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldCompletion = table.Column<int>(type: "int", nullable: false),
                    NewCompletion = table.Column<int>(type: "int", nullable: false),
                    TotalInvoiceCost = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    SiteEngineerId = table.Column<int>(type: "int", nullable: false),
                    SubCosultantID = table.Column<int>(type: "int", nullable: false),
                    subConsultantSubCosultantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineerInvoices", x => x.EngineerInvoiceId);
                    table.ForeignKey(
                        name: "FK_EngineerInvoices_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_EngineerInvoices_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId");
                    table.ForeignKey(
                        name: "FK_EngineerInvoices_SubConsultant_subConsultantSubCosultantID",
                        column: x => x.subConsultantSubCosultantID,
                        principalTable: "SubConsultant",
                        principalColumn: "SubCosultantID");
                });

            migrationBuilder.CreateTable(
                name: "GeneralDrowings",
                columns: table => new
                {
                    GeneralDrowingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dscription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    SubCosultantID = table.Column<int>(type: "int", nullable: false),
                    subConsultantSubCosultantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralDrowings", x => x.GeneralDrowingId);
                    table.ForeignKey(
                        name: "FK_GeneralDrowings_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_GeneralDrowings_SubConsultant_subConsultantSubCosultantID",
                        column: x => x.subConsultantSubCosultantID,
                        principalTable: "SubConsultant",
                        principalColumn: "SubCosultantID");
                });

            migrationBuilder.CreateTable(
                name: "ProjectSubConsultants",
                columns: table => new
                {
                    ProjectSubConsultantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    SubCosultantID = table.Column<int>(type: "int", nullable: false),
                    subConsultantSubCosultantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSubConsultants", x => x.ProjectSubConsultantId);
                    table.ForeignKey(
                        name: "FK_ProjectSubConsultants_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_ProjectSubConsultants_SubConsultant_subConsultantSubCosultantID",
                        column: x => x.subConsultantSubCosultantID,
                        principalTable: "SubConsultant",
                        principalColumn: "SubCosultantID");
                });

            migrationBuilder.CreateTable(
                name: "ShopDrawings",
                columns: table => new
                {
                    ShopDrawingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    SiteEngineerId = table.Column<int>(type: "int", nullable: false),
                    SubCosultantID = table.Column<int>(type: "int", nullable: false),
                    subConsultantSubCosultantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopDrawings", x => x.ShopDrawingId);
                    table.ForeignKey(
                        name: "FK_ShopDrawings_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_ShopDrawings_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId");
                    table.ForeignKey(
                        name: "FK_ShopDrawings_SubConsultant_subConsultantSubCosultantID",
                        column: x => x.subConsultantSubCosultantID,
                        principalTable: "SubConsultant",
                        principalColumn: "SubCosultantID");
                });

            migrationBuilder.CreateTable(
                name: "BoqCondtionEngs",
                columns: table => new
                {
                    BoqCondtionEngId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondtionDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineerBoqID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoqCondtionEngs", x => x.BoqCondtionEngId);
                    table.ForeignKey(
                        name: "FK_BoqCondtionEngs_EngineerBoqs_EngineerBoqID",
                        column: x => x.EngineerBoqID,
                        principalTable: "EngineerBoqs",
                        principalColumn: "EngineerBoqID");
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaterialType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialCount = table.Column<int>(type: "int", nullable: false),
                    MaterialDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectManagerID = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    SubContractorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Material_ProjectManagers_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId");
                    table.ForeignKey(
                        name: "FK_Material_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreID");
                    table.ForeignKey(
                        name: "FK_Material_SubContractors_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractors",
                        principalColumn: "SubContractorId");
                });

            migrationBuilder.CreateTable(
                name: "BoqCondtionConsultants",
                columns: table => new
                {
                    BoqCondtionConsultantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondetionDetails = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ConsultantBoqId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoqCondtionConsultants", x => x.BoqCondtionConsultantId);
                    table.ForeignKey(
                        name: "FK_BoqCondtionConsultants_ConsultantBoqs_ConsultantBoqId",
                        column: x => x.ConsultantBoqId,
                        principalTable: "ConsultantBoqs",
                        principalColumn: "ConsultantBoqId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoqCondtionConsultants_ConsultantBoqId",
                table: "BoqCondtionConsultants",
                column: "ConsultantBoqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoqCondtionEngs_EngineerBoqID",
                table: "BoqCondtionEngs",
                column: "EngineerBoqID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantBoqs_ProjectID",
                table: "ConsultantBoqs",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantBoqs_SiteEngineerId",
                table: "ConsultantBoqs",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantBoqs_SubConsultantID",
                table: "ConsultantBoqs",
                column: "SubConsultantID");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerBoqs_ProjectID",
                table: "EngineerBoqs",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerBoqs_SiteEngineerId",
                table: "EngineerBoqs",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerBoqs_SubContractorId",
                table: "EngineerBoqs",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerInvoices_ProjectID",
                table: "EngineerInvoices",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerInvoices_SiteEngineerId",
                table: "EngineerInvoices",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerInvoices_subConsultantSubCosultantID",
                table: "EngineerInvoices",
                column: "subConsultantSubCosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_Foremen_ProjectManagerId",
                table: "Foremen",
                column: "ProjectManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormanTasks_ForemanId",
                table: "FormanTasks",
                column: "ForemanId");

            migrationBuilder.CreateIndex(
                name: "IX_FormanTasks_ProjectID",
                table: "FormanTasks",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDrowings_ProjectID",
                table: "GeneralDrowings",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDrowings_subConsultantSubCosultantID",
                table: "GeneralDrowings",
                column: "subConsultantSubCosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_MainConsultants_ProjectManagerId",
                table: "MainConsultants",
                column: "ProjectManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_ProjectManagerID",
                table: "Material",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Material_StoreId",
                table: "Material",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SubContractorId",
                table: "Material",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContracts_MainClientId",
                table: "ProjectContracts",
                column: "MainClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContracts_ProjectID",
                table: "ProjectContracts",
                column: "ProjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContracts_ProjectManagerId",
                table: "ProjectContracts",
                column: "ProjectManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ForemanId",
                table: "Projects",
                column: "ForemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_MainClientID",
                table: "Projects",
                column: "MainClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_mainConsultanttMaincosultantID",
                table: "Projects",
                column: "mainConsultanttMaincosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSiteEngineers_ProjectID",
                table: "ProjectSiteEngineers",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSiteEngineers_SiteEngineerId",
                table: "ProjectSiteEngineers",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSubConsultants_ProjectID",
                table: "ProjectSubConsultants",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSubConsultants_subConsultantSubCosultantID",
                table: "ProjectSubConsultants",
                column: "subConsultantSubCosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSubContractors_ProjectID",
                table: "ProjectSubContractors",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSubContractors_SubContractorId",
                table: "ProjectSubContractors",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDrawings_ProjectID",
                table: "ShopDrawings",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDrawings_SiteEngineerId",
                table: "ShopDrawings",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDrawings_subConsultantSubCosultantID",
                table: "ShopDrawings",
                column: "subConsultantSubCosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_SiteEngineer_ProjectManagerID",
                table: "SiteEngineer",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_ForemanId",
                table: "Stores",
                column: "ForemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_ProjectID",
                table: "Stores",
                column: "ProjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_SiteEngineerId",
                table: "Stores",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_SubContractorId",
                table: "Stores",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubConstractorInvoices_ProjectID",
                table: "SubConstractorInvoices",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_SubConstractorInvoices_SiteEngineerId",
                table: "SubConstractorInvoices",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubConstractorInvoices_SubContractorId",
                table: "SubConstractorInvoices",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubConsultant_mainConsultantMaincosultantID",
                table: "SubConsultant",
                column: "mainConsultantMaincosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_SubConsultant_ProjectManagerID",
                table: "SubConsultant",
                column: "ProjectManagerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoqCondtionConsultants");

            migrationBuilder.DropTable(
                name: "BoqCondtionEngs");

            migrationBuilder.DropTable(
                name: "EngineerInvoices");

            migrationBuilder.DropTable(
                name: "FormanTasks");

            migrationBuilder.DropTable(
                name: "GeneralDrowings");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "ProjectContracts");

            migrationBuilder.DropTable(
                name: "ProjectSiteEngineers");

            migrationBuilder.DropTable(
                name: "ProjectSubConsultants");

            migrationBuilder.DropTable(
                name: "ProjectSubContractors");

            migrationBuilder.DropTable(
                name: "ShopDrawings");

            migrationBuilder.DropTable(
                name: "SubConstractorInvoices");

            migrationBuilder.DropTable(
                name: "ConsultantBoqs");

            migrationBuilder.DropTable(
                name: "EngineerBoqs");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "SubConsultant");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "SiteEngineer");

            migrationBuilder.DropTable(
                name: "SubContractors");

            migrationBuilder.DropTable(
                name: "Foremen");

            migrationBuilder.DropTable(
                name: "MainClient");

            migrationBuilder.DropTable(
                name: "MainConsultants");

            migrationBuilder.DropTable(
                name: "ProjectManagers");
        }
    }
}
