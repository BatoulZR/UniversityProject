using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorProject.Migrations
{
    public partial class migra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    AdminConfirmation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Box",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Box_Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Box", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    num = table.Column<long>(nullable: false),
                    Fax = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Freezer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    temperature = table.Column<string>(nullable: true),
                    Cons = table.Column<string>(nullable: true),
                    BoxName = table.Column<string>(nullable: true),
                    BoxType = table.Column<string>(nullable: true),
                    LevelNum = table.Column<int>(nullable: false),
                    Side = table.Column<string>(nullable: true),
                    LevSide = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freezer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LabDay",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    openingTime = table.Column<TimeSpan>(nullable: false),
                    closingTime = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabDay", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Researcher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reseacherName = table.Column<string>(nullable: false),
                    tasks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researcher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bacteria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BacteriaName = table.Column<string>(nullable: true),
                    x = table.Column<int>(nullable: false),
                    y = table.Column<int>(nullable: false),
                    boxID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bacteria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bacteria_Box_boxID",
                        column: x => x.boxID,
                        principalTable: "Box",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accident",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Damages = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    LabDayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accident", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accident_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accident_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assesment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(nullable: false),
                    TraineeId = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    quality = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    work_habits = table.Column<int>(nullable: false),
                    communication = table.Column<int>(nullable: false),
                    attitude = table.Column<int>(nullable: false),
                    professionalism = table.Column<int>(nullable: false),
                    leadership = table.Column<int>(nullable: false),
                    LabDayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assesment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assesment_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assesment_AspNetUsers_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assesment_AspNetUsers_studentId",
                        column: x => x.studentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(nullable: true),
                    LeavingTime = table.Column<TimeSpan>(nullable: true),
                    LabDayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attendance_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Collaboration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColabboratorName = table.Column<string>(nullable: true),
                    Institute = table.Column<string>(nullable: true),
                    Compounds = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    phdM2 = table.Column<string>(nullable: true),
                    Test = table.Column<string>(nullable: true),
                    LabDayId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaboration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Collaboration_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Collaboration_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<string>(nullable: true),
                    firstname = table.Column<string>(nullable: true),
                    fathername = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    requestType = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    speciality = table.Column<string>(nullable: true),
                    year = table.Column<string>(nullable: true),
                    requestStatus = table.Column<bool>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    place = table.Column<string>(nullable: true),
                    duration = table.Column<string>(nullable: true),
                    Paragraph = table.Column<string>(nullable: true),
                    LabDayId = table.Column<int>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Form_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Form_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRoomReservation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    time1 = table.Column<DateTime>(nullable: false),
                    time2 = table.Column<DateTime>(nullable: false),
                    objective = table.Column<string>(nullable: false),
                    summary = table.Column<string>(nullable: true),
                    LabDayId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRoomReservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeetingRoomReservation_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingRoomReservation_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    supervised = table.Column<string>(nullable: true),
                    project = table.Column<string>(nullable: true),
                    university = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true),
                    PagesNumber = table.Column<int>(nullable: false),
                    Colored = table.Column<bool>(nullable: false),
                    BorrowedObject = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    Returned = table.Column<bool>(nullable: false),
                    Work = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    confirmation = table.Column<bool>(nullable: false),
                    LabDayId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Permission_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permission_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    fundingorganism = table.Column<string>(nullable: true),
                    fundingDuration = table.Column<string>(nullable: false),
                    fundAmount = table.Column<string>(nullable: false),
                    from = table.Column<DateTime>(nullable: false),
                    to = table.Column<DateTime>(nullable: false),
                    reasearchAssistantFees = table.Column<bool>(nullable: false),
                    congress = table.Column<bool>(nullable: false),
                    fieldFees = table.Column<bool>(nullable: false),
                    publicationAndPatentFees = table.Column<bool>(nullable: false),
                    consumables = table.Column<bool>(nullable: false),
                    machinesAndEquipements = table.Column<bool>(nullable: false),
                    others = table.Column<string>(nullable: false),
                    collaborationOrNot = table.Column<bool>(nullable: false),
                    LabDayId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rotation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entrancePermission = table.Column<string>(nullable: false),
                    photosAndDemandLetter = table.Column<string>(nullable: false),
                    inventory = table.Column<string>(nullable: false),
                    cafeteriaFees = table.Column<string>(nullable: false),
                    eventsAndCeremonies = table.Column<string>(nullable: false),
                    stockUpdates = table.Column<string>(nullable: false),
                    orderingConsumables = table.Column<string>(nullable: false),
                    month = table.Column<string>(nullable: false),
                    year = table.Column<string>(nullable: false),
                    LabDayId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rotation_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rotation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingPresence",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    mrrId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingPresence", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeetingPresence_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingPresence_MeetingRoomReservation_mrrId",
                        column: x => x.mrrId,
                        principalTable: "MeetingRoomReservation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experiment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Superv = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Desc = table.Column<string>(nullable: true),
                    LabDayId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Experiment_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Experiment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Experiment_Project_projectId",
                        column: x => x.projectId,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(nullable: false),
                    supervisorName = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    specifityNotes = table.Column<string>(nullable: false),
                    dateOfOrder = table.Column<DateTime>(nullable: false),
                    dateOfUsage = table.Column<DateTime>(nullable: false),
                    confirmed = table.Column<bool>(nullable: false),
                    LabDayId = table.Column<int>(nullable: false),
                    companyID = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    projectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Company_companyID",
                        column: x => x.companyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Project_projectId",
                        column: x => x.projectId,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCollaboration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectId = table.Column<int>(nullable: false),
                    collaborationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCollaboration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectCollaboration_Collaboration_collaborationId",
                        column: x => x.collaborationId,
                        principalTable: "Collaboration",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectCollaboration_Project_projectId",
                        column: x => x.projectId,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectResearcher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectId = table.Column<int>(nullable: false),
                    researcherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectResearcher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectResearcher_Project_projectId",
                        column: x => x.projectId,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectResearcher_Researcher_researcherId",
                        column: x => x.researcherId,
                        principalTable: "Researcher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Biowaste",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    Boxnum = table.Column<int>(nullable: false),
                    weight = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    ExperimentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biowaste", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Biowaste_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Biowaste_Experiment_ExperimentId",
                        column: x => x.ExperimentId,
                        principalTable: "Experiment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    Capacity = table.Column<string>(nullable: true),
                    serialNumber = table.Column<string>(nullable: true),
                    weight = table.Column<int>(nullable: true),
                    units = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: true),
                    arrivalDate = table.Column<DateTime>(nullable: false),
                    expiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    notes = table.Column<string>(nullable: true),
                    room = table.Column<string>(nullable: true),
                    calibration = table.Column<bool>(nullable: false),
                    inUse = table.Column<bool>(nullable: false),
                    expired = table.Column<bool>(nullable: false),
                    remainingQuantity = table.Column<bool>(nullable: false),
                    quantityUsed = table.Column<int>(nullable: false),
                    from = table.Column<TimeSpan>(nullable: false),
                    to = table.Column<TimeSpan>(nullable: false),
                    exId = table.Column<int>(nullable: false),
                    ex_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Item_Experiment_ex_id",
                        column: x => x.ex_id,
                        principalTable: "Experiment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestingAndCalibration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    nextCheck = table.Column<DateTime>(nullable: false),
                    LabDayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingAndCalibration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TestingAndCalibration_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestingAndCalibration_LabDay_LabDayId",
                        column: x => x.LabDayId,
                        principalTable: "LabDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestingAndCalibration_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accident_LabDayId",
                table: "Accident",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Accident_UserId",
                table: "Accident",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Assesment_LabDayId",
                table: "Assesment",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Assesment_TraineeId",
                table: "Assesment",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assesment_studentId",
                table: "Assesment",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_LabDayId",
                table: "Attendance",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_UserId",
                table: "Attendance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bacteria_boxID",
                table: "Bacteria",
                column: "boxID");

            migrationBuilder.CreateIndex(
                name: "IX_Biowaste_CompanyId",
                table: "Biowaste",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Biowaste_ExperimentId",
                table: "Biowaste",
                column: "ExperimentId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaboration_AppUserId",
                table: "Collaboration",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaboration_LabDayId",
                table: "Collaboration",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ex_id",
                table: "Item",
                column: "ex_id");

            migrationBuilder.CreateIndex(
                name: "IX_Experiment_LabDayId",
                table: "Experiment",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiment_UserId",
                table: "Experiment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiment_projectId",
                table: "Experiment",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_Form_AppUserId",
                table: "Form",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Form_LabDayId",
                table: "Form",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPresence_UserId",
                table: "MeetingPresence",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPresence_mrrId",
                table: "MeetingPresence",
                column: "mrrId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRoomReservation_AppUserId",
                table: "MeetingRoomReservation",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRoomReservation_LabDayId",
                table: "MeetingRoomReservation",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_LabDayId",
                table: "Order",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_companyID",
                table: "Order",
                column: "companyID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_projectId",
                table: "Order",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_AppUserId",
                table: "Permission",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_LabDayId",
                table: "Permission",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_AppUserId",
                table: "Project",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_LabDayId",
                table: "Project",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCollaboration_collaborationId",
                table: "ProjectCollaboration",
                column: "collaborationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCollaboration_projectId",
                table: "ProjectCollaboration",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectResearcher_projectId",
                table: "ProjectResearcher",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectResearcher_researcherId",
                table: "ProjectResearcher",
                column: "researcherId");

            migrationBuilder.CreateIndex(
                name: "IX_Rotation_LabDayId",
                table: "Rotation",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Rotation_UserId",
                table: "Rotation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestingAndCalibration_ItemId",
                table: "TestingAndCalibration",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TestingAndCalibration_LabDayId",
                table: "TestingAndCalibration",
                column: "LabDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TestingAndCalibration_UserId",
                table: "TestingAndCalibration",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accident");

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
                name: "Assesment");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Bacteria");

            migrationBuilder.DropTable(
                name: "Biowaste");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "Freezer");

            migrationBuilder.DropTable(
                name: "MeetingPresence");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "ProjectCollaboration");

            migrationBuilder.DropTable(
                name: "ProjectResearcher");

            migrationBuilder.DropTable(
                name: "Rotation");

            migrationBuilder.DropTable(
                name: "TestingAndCalibration");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Box");

            migrationBuilder.DropTable(
                name: "MeetingRoomReservation");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Collaboration");

            migrationBuilder.DropTable(
                name: "Researcher");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Experiment");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LabDay");
        }
    }
}
