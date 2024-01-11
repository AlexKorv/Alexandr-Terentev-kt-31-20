using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace terentevalexandrKt_31_20.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "educationalsubject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Наименование дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_educationalsubject_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    middlename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Отчество преподавателя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_professor_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workload",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор нагрузки")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    professor_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор профессора"),
                    educationsubject_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины"),
                    numberofhours = table.Column<int>(type: "int", nullable: false, comment: "Количество часов нагрузки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workload_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_f_educationalsubject_id",
                        column: x => x.educationsubject_id,
                        principalTable: "educationalsubject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_professor_id",
                        column: x => x.professor_id,
                        principalTable: "professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_workload_educationsubject_id",
                table: "workload",
                column: "educationsubject_id");

            migrationBuilder.CreateIndex(
                name: "IX_workload_professor_id",
                table: "workload",
                column: "professor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workload");

            migrationBuilder.DropTable(
                name: "educationalsubject");

            migrationBuilder.DropTable(
                name: "professor");
        }
    }
}
