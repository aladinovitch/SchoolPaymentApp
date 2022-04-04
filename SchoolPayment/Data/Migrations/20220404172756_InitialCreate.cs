using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPayment.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SchoolPayment");

            migrationBuilder.CreateTable(
                name: "Module",
                schema: "SchoolPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "SchoolPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Registration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                schema: "SchoolPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                schema: "SchoolPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "SchoolPayment",
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                schema: "SchoolPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposit_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "SchoolPayment",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "SchoolPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "SchoolPayment",
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animation",
                schema: "SchoolPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attendance = table.Column<bool>(type: "bit", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animation_Session_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "SchoolPayment",
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animation_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "SchoolPayment",
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participation",
                schema: "SchoolPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attendance = table.Column<bool>(type: "bit", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participation_Session_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "SchoolPayment",
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participation_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "SchoolPayment",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "16683553-5dff-4c96-ae6b-085564384449", 0, "5b19a28e-e2ea-4087-a192-e1a4780c3dd2", "basic@email.com", true, false, null, "BASIC@EMAIL.COM", "BASIC@EMAIL.COM", "AQAAAAEAACcQAAAAEKnDlDYvOQtA5KSQKeXL5KWcnHuroNJHyjtaWnmjg0PycrC/ACrfclBXXi6g6eQAjQ==", null, false, "b14bbf6a-9b07-4826-adc0-8492889352a0", false, "basic@email.com" },
                    { "4a71d9e0-6de8-4a5c-8a7d-f42747142a86", 0, "d5d5f3f3-d259-4472-95f7-85b5c204267a", "manager@email.com", true, false, null, "MANAGER@EMAIL.COM", "MANAGER@EMAIL.COM", "AQAAAAEAACcQAAAAECa0gBQ7+8zJZCawxf8NPtzTp8TaPs1JC0nBZL5+gn7dY2rU2tXVR6YiXeQibu+2tQ==", null, false, "3eda00dc-aeb2-4d03-b45d-58095baac150", false, "manager@email.com" }
                });

            migrationBuilder.InsertData(
                schema: "SchoolPayment",
                table: "Module",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, null, "English : Introductory Course" },
                    { 2, null, "Français : Terminale littéraire" },
                    { 3, null, "Math : Third year midschool" },
                    { 4, null, "Physics : Final year scientific " }
                });

            migrationBuilder.InsertData(
                schema: "SchoolPayment",
                table: "Student",
                columns: new[] { "Id", "Birthdate", "Discount", "Fname", "Lname", "Number", "Registration" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, "Hicham", "Bouhachemi", "2020/26/001", new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2000, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.05f, "Youcef", "Benyoucef", "2020/26/002", new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2000, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1f, "Abdelkader", "Boukadir", "2020/26/003", new DateTime(2020, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2000, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.15f, "Yousra", "Yassira", "2020/26/004", new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2000, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.2f, "Bouchra", "Benbacha", "2020/26/005", new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2000, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.25f, "Amina", "Benamina", "2020/26/004", new DateTime(2020, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "SchoolPayment",
                table: "Teacher",
                columns: new[] { "Id", "Birthdate", "Fname", "Lname", "Number" },
                values: new object[,]
                {
                    { 1, new DateTime(1981, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amer", "Benamer", "E001" },
                    { 2, new DateTime(1982, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ilham", "Benilham", "E002" },
                    { 3, new DateTime(1983, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ismail", "Bousmail", "E003" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Manage Role", "true", "4a71d9e0-6de8-4a5c-8a7d-f42747142a86" },
                    { 2, "Basic Role", "true", "16683553-5dff-4c96-ae6b-085564384449" }
                });

            migrationBuilder.InsertData(
                schema: "SchoolPayment",
                table: "Deposit",
                columns: new[] { "Id", "Amount", "Date", "StudentId" },
                values: new object[,]
                {
                    { 1, 1000, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 950, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 2000, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 1950, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 1900, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 3000, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 2900, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, 2800, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, 2700, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                schema: "SchoolPayment",
                table: "Payment",
                columns: new[] { "Id", "Amount", "Date", "TeacherId" },
                values: new object[,]
                {
                    { 1, 15000, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 17000, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 19000, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 25000, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 27000, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 29000, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 30000, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, 32000, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, 35000, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                schema: "SchoolPayment",
                table: "Session",
                columns: new[] { "Id", "Date", "ModuleId", "Number" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 4, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 5, new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 6, new DateTime(2021, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 7, new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 8, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 9, new DateTime(2021, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 10, new DateTime(2021, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 11, new DateTime(2021, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 12, new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 }
                });

            migrationBuilder.InsertData(
                schema: "SchoolPayment",
                table: "Animation",
                columns: new[] { "Id", "Attendance", "Observation", "SessionId", "TeacherId" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 2, 1 },
                    { 3, false, "Meeting to discuss progress", 3, 1 },
                    { 4, true, null, 1, 1 },
                    { 5, false, "Long weekend", 2, 1 },
                    { 6, true, null, 3, 1 },
                    { 7, true, null, 1, 3 },
                    { 8, true, null, 2, 3 }
                });

            migrationBuilder.InsertData(
                schema: "SchoolPayment",
                table: "Participation",
                columns: new[] { "Id", "Attendance", "Observation", "SessionId", "StudentId" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 2, 1 },
                    { 3, true, null, 3, 1 },
                    { 4, false, "Study for exams", 4, 1 },
                    { 5, true, null, 1, 2 },
                    { 6, true, null, 2, 2 },
                    { 7, true, null, 3, 2 },
                    { 8, true, null, 4, 2 },
                    { 9, true, null, 1, 3 },
                    { 10, true, null, 2, 3 },
                    { 11, false, "Abandon", 3, 3 },
                    { 12, false, "Abandon", 4, 3 },
                    { 13, true, null, 1, 4 },
                    { 14, true, null, 2, 4 },
                    { 15, true, null, 3, 4 },
                    { 16, true, null, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animation_SessionId",
                schema: "SchoolPayment",
                table: "Animation",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Animation_TeacherId",
                schema: "SchoolPayment",
                table: "Animation",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_StudentId",
                schema: "SchoolPayment",
                table: "Deposit",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_SessionId",
                schema: "SchoolPayment",
                table: "Participation",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_StudentId",
                schema: "SchoolPayment",
                table: "Participation",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_TeacherId",
                schema: "SchoolPayment",
                table: "Payment",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_ModuleId",
                schema: "SchoolPayment",
                table: "Session",
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animation",
                schema: "SchoolPayment");

            migrationBuilder.DropTable(
                name: "Deposit",
                schema: "SchoolPayment");

            migrationBuilder.DropTable(
                name: "Participation",
                schema: "SchoolPayment");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "SchoolPayment");

            migrationBuilder.DropTable(
                name: "Session",
                schema: "SchoolPayment");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "SchoolPayment");

            migrationBuilder.DropTable(
                name: "Teacher",
                schema: "SchoolPayment");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "SchoolPayment");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16683553-5dff-4c96-ae6b-085564384449");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a71d9e0-6de8-4a5c-8a7d-f42747142a86");
        }
    }
}
