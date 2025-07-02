using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolTracker.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InheritFromAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassYears_ClassYearID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Profesors_ProfesorID",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Profesors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "AppUser");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassYearID",
                table: "AppUser",
                newName: "IX_AppUser_ClassYearID");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AppUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AppUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ClassYearID",
                table: "AppUser",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Student_Email",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_FirstName",
                table: "AppUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_LastName",
                table: "AppUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "AppUser",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_ClassYears_ClassYearID",
                table: "AppUser",
                column: "ClassYearID",
                principalTable: "ClassYears",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_AppUser_StudentID",
                table: "Grades",
                column: "StudentID",
                principalTable: "AppUser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AppUser_ProfesorID",
                table: "Subjects",
                column: "ProfesorID",
                principalTable: "AppUser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_ClassYears_ClassYearID",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_AppUser_StudentID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AppUser_ProfesorID",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Student_Email",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Student_FirstName",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Student_LastName",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AppUser");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_ClassYearID",
                table: "Students",
                newName: "IX_Students_ClassYearID");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassYearID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Profesors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesors", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentID",
                table: "Grades",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassYears_ClassYearID",
                table: "Students",
                column: "ClassYearID",
                principalTable: "ClassYears",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Profesors_ProfesorID",
                table: "Subjects",
                column: "ProfesorID",
                principalTable: "Profesors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
