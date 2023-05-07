using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseRegistrationWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deptID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    creditHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_deptID",
                        column: x => x.deptID,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deptID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    postfixCharacter = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    semesterNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sections_Departments_deptID",
                        column: x => x.deptID,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TheoryCourses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheoryCourses", x => x.id);
                    table.ForeignKey(
                        name: "FK_TheoryCourses_Courses_id",
                        column: x => x.id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CourseLogs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    courseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    teacherID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sectionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseLogs_Courses_courseID",
                        column: x => x.courseID,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseLogs_Sections_sectionID",
                        column: x => x.sectionID,
                        principalTable: "Sections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseLogs_Teachers_teacherID",
                        column: x => x.teacherID,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sectionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    batchYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Sections_sectionID",
                        column: x => x.sectionID,
                        principalTable: "Sections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoreCourses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prevChainID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreCourses", x => x.id);
                    table.ForeignKey(
                        name: "FK_CoreCourses_CoreCourses_prevChainID",
                        column: x => x.prevChainID,
                        principalTable: "CoreCourses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CoreCourses_TheoryCourses_id",
                        column: x => x.id,
                        principalTable: "TheoryCourses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LabCourses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    theoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabCourses", x => x.id);
                    table.ForeignKey(
                        name: "FK_LabCourses_Courses_id",
                        column: x => x.id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LabCourses_TheoryCourses_theoryID",
                        column: x => x.theoryID,
                        principalTable: "TheoryCourses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredCourses",
                columns: table => new
                {
                    studentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    courseLogID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredCourses", x => new { x.studentID, x.courseLogID });
                    table.ForeignKey(
                        name: "FK_RegisteredCourses_CourseLogs_courseLogID",
                        column: x => x.courseLogID,
                        principalTable: "CourseLogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RegisteredCourses_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StudentLogins",
                columns: table => new
                {
                    studentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLogins", x => x.studentID);
                    table.ForeignKey(
                        name: "FK_StudentLogins_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoreCourses_prevChainID",
                table: "CoreCourses",
                column: "prevChainID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseLogs_courseID",
                table: "CourseLogs",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLogs_sectionID",
                table: "CourseLogs",
                column: "sectionID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLogs_teacherID",
                table: "CourseLogs",
                column: "teacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_deptID",
                table: "Courses",
                column: "deptID");

            migrationBuilder.CreateIndex(
                name: "IX_LabCourses_theoryID",
                table: "LabCourses",
                column: "theoryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredCourses_courseLogID",
                table: "RegisteredCourses",
                column: "courseLogID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_deptID",
                table: "Sections",
                column: "deptID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_sectionID",
                table: "Students",
                column: "sectionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoreCourses");

            migrationBuilder.DropTable(
                name: "LabCourses");

            migrationBuilder.DropTable(
                name: "RegisteredCourses");

            migrationBuilder.DropTable(
                name: "StudentLogins");

            migrationBuilder.DropTable(
                name: "TheoryCourses");

            migrationBuilder.DropTable(
                name: "CourseLogs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
