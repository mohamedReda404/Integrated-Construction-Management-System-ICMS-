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
                name: "MainClients",
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
                    table.PrimaryKey("PK_MainClients", x => x.MainClientID);
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
                name: "SubContractor",
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
                    table.PrimaryKey("PK_SubContractor", x => x.SubContractorId);
                });

            migrationBuilder.CreateTable(
                name: "Foreman",
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
                    table.PrimaryKey("PK_Foreman", x => x.ForemanId);
                    table.ForeignKey(
                        name: "FK_Foreman_ProjectManagers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainConsultant",
                columns: table => new
                {
                    MainCosultantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCosultantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainConsultant", x => x.MainCosultantID);
                    table.ForeignKey(
                        name: "FK_MainConsultant_ProjectManagers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "ProjectManagerId",
                        onDelete: ReferentialAction.Cascade);
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
                    ProjectManagerID = table.Column<int>(type: "int", nullable: false),
                    FormanID = table.Column<int>(type: "int", nullable: false),
                    _foremanForemanId = table.Column<int>(type: "int", nullable: true),
                    MainCosultantID = table.Column<int>(type: "int", nullable: false),
                    _mainConsultantMainCosultantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_Foreman__foremanForemanId",
                        column: x => x._foremanForemanId,
                        principalTable: "Foreman",
                        principalColumn: "ForemanId");
                    table.ForeignKey(
                        name: "FK_Projects_MainClients_MainClientID",
                        column: x => x.MainClientID,
                        principalTable: "MainClients",
                        principalColumn: "MainClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_MainConsultant__mainConsultantMainCosultantID",
                        column: x => x._mainConsultantMainCosultantID,
                        principalTable: "MainConsultant",
                        principalColumn: "MainCosultantID");
                    table.ForeignKey(
                        name: "FK_Projects_ProjectManagers_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId",
                        onDelete: ReferentialAction.Cascade);
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
                    mainConsultantMainCosultantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubConsultant", x => x.SubCosultantID);
                    table.ForeignKey(
                        name: "FK_SubConsultant_MainConsultant_mainConsultantMainCosultantID",
                        column: x => x.mainConsultantMainCosultantID,
                        principalTable: "MainConsultant",
                        principalColumn: "MainCosultantID");
                    table.ForeignKey(
                        name: "FK_SubConsultant_ProjectManagers_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngineerBoq",
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
                    table.PrimaryKey("PK_EngineerBoq", x => x.EngineerBoqID);
                    table.ForeignKey(
                        name: "FK_EngineerBoq_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineerBoq_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId");
                    table.ForeignKey(
                        name: "FK_EngineerBoq_SubContractor_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractor",
                        principalColumn: "SubContractorId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_FormanTasks_Foreman_ForemanId",
                        column: x => x.ForemanId,
                        principalTable: "Foreman",
                        principalColumn: "ForemanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormanTasks_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContract",
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
                    table.PrimaryKey("PK_ProjectContract", x => x.ProjectContractId);
                    table.ForeignKey(
                        name: "FK_ProjectContract_MainClients_MainClientId",
                        column: x => x.MainClientId,
                        principalTable: "MainClients",
                        principalColumn: "MainClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectContract_ProjectManagers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectContract_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSiteEngineer",
                columns: table => new
                {
                    ProjectSiteEngineerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    SiteEngineerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSiteEngineer", x => x.ProjectSiteEngineerID);
                    table.ForeignKey(
                        name: "FK_ProjectSiteEngineer_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSiteEngineer_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSubContractor",
                columns: table => new
                {
                    ProjectSubContractorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    SubContractorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSubContractor", x => x.ProjectSubContractorId);
                    table.ForeignKey(
                        name: "FK_ProjectSubContractor_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSubContractor_SubContractor_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractor",
                        principalColumn: "SubContractorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
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
                    table.PrimaryKey("PK_Store", x => x.StoreID);
                    table.ForeignKey(
                        name: "FK_Store_Foreman_ForemanId",
                        column: x => x.ForemanId,
                        principalTable: "Foreman",
                        principalColumn: "ForemanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_SubContractor_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractor",
                        principalColumn: "SubContractorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubConstractorInvoice",
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
                    table.PrimaryKey("PK_SubConstractorInvoice", x => x.SubConstractorInvoiceId);
                    table.ForeignKey(
                        name: "FK_SubConstractorInvoice_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubConstractorInvoice_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubConstractorInvoice_SubContractor_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractor",
                        principalColumn: "SubContractorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultantBoq",
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
                    table.PrimaryKey("PK_ConsultantBoq", x => x.ConsultantBoqId);
                    table.ForeignKey(
                        name: "FK_ConsultantBoq_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantBoq_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantBoq_SubConsultant_SubConsultantID",
                        column: x => x.SubConsultantID,
                        principalTable: "SubConsultant",
                        principalColumn: "SubCosultantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngineerInvoice",
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
                    table.PrimaryKey("PK_EngineerInvoice", x => x.EngineerInvoiceId);
                    table.ForeignKey(
                        name: "FK_EngineerInvoice_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineerInvoice_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineerInvoice_SubConsultant_subConsultantSubCosultantID",
                        column: x => x.subConsultantSubCosultantID,
                        principalTable: "SubConsultant",
                        principalColumn: "SubCosultantID");
                });

            migrationBuilder.CreateTable(
                name: "GeneralDrowing",
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
                    table.PrimaryKey("PK_GeneralDrowing", x => x.GeneralDrowingId);
                    table.ForeignKey(
                        name: "FK_GeneralDrowing_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralDrowing_SubConsultant_subConsultantSubCosultantID",
                        column: x => x.subConsultantSubCosultantID,
                        principalTable: "SubConsultant",
                        principalColumn: "SubCosultantID");
                });

            migrationBuilder.CreateTable(
                name: "ProjectSubConsultant",
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
                    table.PrimaryKey("PK_ProjectSubConsultant", x => x.ProjectSubConsultantId);
                    table.ForeignKey(
                        name: "FK_ProjectSubConsultant_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSubConsultant_SubConsultant_subConsultantSubCosultantID",
                        column: x => x.subConsultantSubCosultantID,
                        principalTable: "SubConsultant",
                        principalColumn: "SubCosultantID");
                });

            migrationBuilder.CreateTable(
                name: "ShopDrawing",
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
                    table.PrimaryKey("PK_ShopDrawing", x => x.ShopDrawingId);
                    table.ForeignKey(
                        name: "FK_ShopDrawing_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopDrawing_SiteEngineer_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineer",
                        principalColumn: "SiteEngineerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopDrawing_SubConsultant_subConsultantSubCosultantID",
                        column: x => x.subConsultantSubCosultantID,
                        principalTable: "SubConsultant",
                        principalColumn: "SubCosultantID");
                });

            migrationBuilder.CreateTable(
                name: "BoqCondtionEng",
                columns: table => new
                {
                    BoqCondtionEngId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondtionDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineerBoqID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoqCondtionEng", x => x.BoqCondtionEngId);
                    table.ForeignKey(
                        name: "FK_BoqCondtionEng_EngineerBoq_EngineerBoqID",
                        column: x => x.EngineerBoqID,
                        principalTable: "EngineerBoq",
                        principalColumn: "EngineerBoqID",
                        onDelete: ReferentialAction.Cascade);
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
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Material_ProjectManagers_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "ProjectManagers",
                        principalColumn: "ProjectManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Material_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoqCondtionConsultant",
                columns: table => new
                {
                    BoqCondtionConsultantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondetionDetails = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ConsultantBoqId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoqCondtionConsultant", x => x.BoqCondtionConsultantId);
                    table.ForeignKey(
                        name: "FK_BoqCondtionConsultant_ConsultantBoq_ConsultantBoqId",
                        column: x => x.ConsultantBoqId,
                        principalTable: "ConsultantBoq",
                        principalColumn: "ConsultantBoqId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoqCondtionConsultant_ConsultantBoqId",
                table: "BoqCondtionConsultant",
                column: "ConsultantBoqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoqCondtionEng_EngineerBoqID",
                table: "BoqCondtionEng",
                column: "EngineerBoqID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantBoq_ProjectID",
                table: "ConsultantBoq",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantBoq_SiteEngineerId",
                table: "ConsultantBoq",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantBoq_SubConsultantID",
                table: "ConsultantBoq",
                column: "SubConsultantID");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerBoq_ProjectID",
                table: "EngineerBoq",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerBoq_SiteEngineerId",
                table: "EngineerBoq",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerBoq_SubContractorId",
                table: "EngineerBoq",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerInvoice_ProjectID",
                table: "EngineerInvoice",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerInvoice_SiteEngineerId",
                table: "EngineerInvoice",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerInvoice_subConsultantSubCosultantID",
                table: "EngineerInvoice",
                column: "subConsultantSubCosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_Foreman_ProjectManagerId",
                table: "Foreman",
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
                name: "IX_GeneralDrowing_ProjectID",
                table: "GeneralDrowing",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDrowing_subConsultantSubCosultantID",
                table: "GeneralDrowing",
                column: "subConsultantSubCosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_MainConsultant_ProjectManagerId",
                table: "MainConsultant",
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
                name: "IX_ProjectContract_MainClientId",
                table: "ProjectContract",
                column: "MainClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContract_ProjectID",
                table: "ProjectContract",
                column: "ProjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContract_ProjectManagerId",
                table: "ProjectContract",
                column: "ProjectManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects__foremanForemanId",
                table: "Projects",
                column: "_foremanForemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects__mainConsultantMainCosultantID",
                table: "Projects",
                column: "_mainConsultantMainCosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_MainClientID",
                table: "Projects",
                column: "MainClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerID",
                table: "Projects",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSiteEngineer_ProjectID",
                table: "ProjectSiteEngineer",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSiteEngineer_SiteEngineerId",
                table: "ProjectSiteEngineer",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSubConsultant_ProjectID",
                table: "ProjectSubConsultant",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSubConsultant_subConsultantSubCosultantID",
                table: "ProjectSubConsultant",
                column: "subConsultantSubCosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSubContractor_ProjectID",
                table: "ProjectSubContractor",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSubContractor_SubContractorId",
                table: "ProjectSubContractor",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDrawing_ProjectID",
                table: "ShopDrawing",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDrawing_SiteEngineerId",
                table: "ShopDrawing",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDrawing_subConsultantSubCosultantID",
                table: "ShopDrawing",
                column: "subConsultantSubCosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_SiteEngineer_ProjectManagerID",
                table: "SiteEngineer",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ForemanId",
                table: "Store",
                column: "ForemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ProjectID",
                table: "Store",
                column: "ProjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Store_SiteEngineerId",
                table: "Store",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_SubContractorId",
                table: "Store",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubConstractorInvoice_ProjectID",
                table: "SubConstractorInvoice",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_SubConstractorInvoice_SiteEngineerId",
                table: "SubConstractorInvoice",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubConstractorInvoice_SubContractorId",
                table: "SubConstractorInvoice",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubConsultant_mainConsultantMainCosultantID",
                table: "SubConsultant",
                column: "mainConsultantMainCosultantID");

            migrationBuilder.CreateIndex(
                name: "IX_SubConsultant_ProjectManagerID",
                table: "SubConsultant",
                column: "ProjectManagerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoqCondtionConsultant");

            migrationBuilder.DropTable(
                name: "BoqCondtionEng");

            migrationBuilder.DropTable(
                name: "EngineerInvoice");

            migrationBuilder.DropTable(
                name: "FormanTasks");

            migrationBuilder.DropTable(
                name: "GeneralDrowing");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "ProjectContract");

            migrationBuilder.DropTable(
                name: "ProjectSiteEngineer");

            migrationBuilder.DropTable(
                name: "ProjectSubConsultant");

            migrationBuilder.DropTable(
                name: "ProjectSubContractor");

            migrationBuilder.DropTable(
                name: "ShopDrawing");

            migrationBuilder.DropTable(
                name: "SubConstractorInvoice");

            migrationBuilder.DropTable(
                name: "ConsultantBoq");

            migrationBuilder.DropTable(
                name: "EngineerBoq");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "SubConsultant");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "SiteEngineer");

            migrationBuilder.DropTable(
                name: "SubContractor");

            migrationBuilder.DropTable(
                name: "Foreman");

            migrationBuilder.DropTable(
                name: "MainClients");

            migrationBuilder.DropTable(
                name: "MainConsultant");

            migrationBuilder.DropTable(
                name: "ProjectManagers");
        }
    }
}
