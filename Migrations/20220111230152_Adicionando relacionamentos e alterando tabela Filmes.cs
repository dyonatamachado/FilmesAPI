using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesApi.Migrations
{
    public partial class AdicionandorelacionamentosealterandotabelaFilmes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Endereco_EnderecoId",
                table: "Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerente_GerenteId",
                table: "Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Cinemas_CinemaId",
                table: "Sessao");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filmes_FilmeId",
                table: "Sessao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gerente",
                table: "Gerente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameTable(
                name: "Sessao",
                newName: "Sessoes");

            migrationBuilder.RenameTable(
                name: "Gerente",
                newName: "Gerentes");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Enderecos");

            migrationBuilder.RenameIndex(
                name: "IX_Sessao_FilmeId",
                table: "Sessoes",
                newName: "IX_Sessoes_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessao_CinemaId",
                table: "Sessoes",
                newName: "IX_Sessoes_CinemaId");

            migrationBuilder.AddColumn<int>(
                name: "ClassificacaoEtaria",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gerentes",
                table: "Gerentes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Enderecos_EnderecoId",
                table: "Cinemas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteId",
                table: "Cinemas",
                column: "GerenteId",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Enderecos_EnderecoId",
                table: "Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteId",
                table: "Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gerentes",
                table: "Gerentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "ClassificacaoEtaria",
                table: "Filmes");

            migrationBuilder.RenameTable(
                name: "Sessoes",
                newName: "Sessao");

            migrationBuilder.RenameTable(
                name: "Gerentes",
                newName: "Gerente");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereco");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_FilmeId",
                table: "Sessao",
                newName: "IX_Sessao_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_CinemaId",
                table: "Sessao",
                newName: "IX_Sessao_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gerente",
                table: "Gerente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Endereco_EnderecoId",
                table: "Cinemas",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerente_GerenteId",
                table: "Cinemas",
                column: "GerenteId",
                principalTable: "Gerente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Cinemas_CinemaId",
                table: "Sessao",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filmes_FilmeId",
                table: "Sessao",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
