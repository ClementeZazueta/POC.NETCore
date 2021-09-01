using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddSomeRowsToToysTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.Toys VALUES ('Toy 1', 'Description of toy number 1', 0, 'MyToy Company', 6.3, 'route/images/photo')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM dbo.Toys WHERE Id = 1");
        }
    }
}
