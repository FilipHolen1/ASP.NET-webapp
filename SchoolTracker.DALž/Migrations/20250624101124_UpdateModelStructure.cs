using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolTracker.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Razredi_RazredId",
                table: "Studenti");

            migrationBuilder.DropTable(
                name: "Razredi");

            migrationBuilder.DropTable(
                name: "StudentPredmeti");

            migrationBuilder.DropTable(
                name: "Predmeti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studenti",
                table: "Studenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesori",
                table: "Profesori");

            migrationBuilder.RenameTable(
                name: "Studenti",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Profesori",
                newName: "Profesors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RazredId",
                table: "Students",
                newName: "ClassYearID");

            migrationBuilder.RenameColumn(
                name: "Prezime",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Ime",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "DatumRodjenja",
                table: "Students",
                newName: "DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Studenti_RazredId",
                table: "Students",
                newName: "IX_Students_ClassYearID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profesors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Prezime",
                table: "Profesors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Ime",
                table: "Profesors",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Profesors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesors",
                table: "Profesors",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ClassYears",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassYears", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfesorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subjects_Profesors_ProfesorID",
                        column: x => x.ProfesorID,
                        principalTable: "Profesors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => new { x.StudentID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectID",
                table: "Grades",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ProfesorID",
                table: "Subjects",
                column: "ProfesorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassYears_ClassYearID",
                table: "Students",
                column: "ClassYearID",
                principalTable: "ClassYears",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassYears_ClassYearID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ClassYears");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesors",
                table: "Profesors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Profesors");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Studenti");

            migrationBuilder.RenameTable(
                name: "Profesors",
                newName: "Profesori");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Studenti",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Studenti",
                newName: "Prezime");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Studenti",
                newName: "Ime");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Studenti",
                newName: "DatumRodjenja");

            migrationBuilder.RenameColumn(
                name: "ClassYearID",
                table: "Studenti",
                newName: "RazredId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassYearID",
                table: "Studenti",
                newName: "IX_Studenti_RazredId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Profesori",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Profesori",
                newName: "Prezime");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Profesori",
                newName: "Ime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studenti",
                table: "Studenti",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesori",
                table: "Profesori",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Predmeti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmeti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predmeti_Profesori_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Razredi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razredi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentPredmeti",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PredmetId = table.Column<int>(type: "int", nullable: false),
                    Ocjena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPredmeti", x => new { x.StudentId, x.PredmetId });
                    table.ForeignKey(
                        name: "FK_StudentPredmeti_Predmeti_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmeti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPredmeti_Studenti_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Predmeti_ProfesorId",
                table: "Predmeti",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPredmeti_PredmetId",
                table: "StudentPredmeti",
                column: "PredmetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Razredi_RazredId",
                table: "Studenti",
                column: "RazredId",
                principalTable: "Razredi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
