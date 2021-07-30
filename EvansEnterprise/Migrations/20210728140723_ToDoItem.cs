using Microsoft.EntityFrameworkCore.Migrations;

namespace EvansEnterprise.Migrations
{
    public partial class ToDoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ToDoItem",
            //    columns: table => new
            //    {
            //        ToDoItemId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Number = table.Column<int>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        IsCompete = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ToDoItem", x => x.ToDoItemId);
            //    });

            migrationBuilder.RenameColumn( name: "IsCompete",    table: "ToDoItem", newName: "IsComplete");
        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.DropTable(                name: "ToDoItem");
            migrationBuilder.RenameColumn(name: "IsComplete", table: "ToDoItem", newName: "IsCompete");

        }
    }
}
