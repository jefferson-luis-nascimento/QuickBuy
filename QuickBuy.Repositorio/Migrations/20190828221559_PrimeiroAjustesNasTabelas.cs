using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.Repositorio.Migrations
{
    public partial class PrimeiroAjustesNasTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_FormasPagamento_FormaPagamentoId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormasPagamento",
                table: "FormasPagamento");

            migrationBuilder.RenameTable(
                name: "FormasPagamento",
                newName: "FormasPagamentos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormasPagamentos",
                table: "FormasPagamentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_FormasPagamentos_FormaPagamentoId",
                table: "Pedidos",
                column: "FormaPagamentoId",
                principalTable: "FormasPagamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_FormasPagamentos_FormaPagamentoId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormasPagamentos",
                table: "FormasPagamentos");

            migrationBuilder.RenameTable(
                name: "FormasPagamentos",
                newName: "FormasPagamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormasPagamento",
                table: "FormasPagamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_FormasPagamento_FormaPagamentoId",
                table: "Pedidos",
                column: "FormaPagamentoId",
                principalTable: "FormasPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
