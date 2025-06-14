using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ejemplo_EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tareas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("dee61528-3227-436a-b19a-280e06686c02"), "Actividades de Carácter Personal", "Actividades Personales", 50 },
                    { new Guid("dee61528-3227-436a-b19a-280e06686c85"), "Actividades de Trabajo y/o escuela", "Actividades Pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("a50f2609-7f0c-46cc-8352-d2b40065a910"), new Guid("dee61528-3227-436a-b19a-280e06686c02"), "Terminar de ver en Neflix", new DateTime(2025, 6, 11, 20, 25, 0, 0, DateTimeKind.Unspecified), 0, "Terminar de ver Película Eso" },
                    { new Guid("a50f2609-7f0c-46cc-8352-d2b40065a9f0"), new Guid("dee61528-3227-436a-b19a-280e06686c85"), "Pagar servicios de Agua y Luz", new DateTime(2025, 6, 11, 20, 19, 0, 0, DateTimeKind.Unspecified), 1, "Pago de servicios" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: new Guid("a50f2609-7f0c-46cc-8352-d2b40065a910"));

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: new Guid("a50f2609-7f0c-46cc-8352-d2b40065a9f0"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: new Guid("dee61528-3227-436a-b19a-280e06686c02"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: new Guid("dee61528-3227-436a-b19a-280e06686c85"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tareas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
