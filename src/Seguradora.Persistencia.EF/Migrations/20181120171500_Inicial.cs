using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Seguradora.Persistencia.EF.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Residencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rua = table.Column<string>(maxLength: 100, nullable: false),
                    Numero = table.Column<short>(nullable: true),
                    Bairro = table.Column<string>(maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vidas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeguroSegurado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SeguroId = table.Column<int>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: true),
                    VidaId = table.Column<int>(nullable: true),
                    ResidenciaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguroSegurado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeguroSegurado_Residencias_ResidenciaId",
                        column: x => x.ResidenciaId,
                        principalTable: "Residencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeguroSegurado_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeguroSegurado_Vidas_VidaId",
                        column: x => x.VidaId,
                        principalTable: "Vidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seguros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CpfCnpj = table.Column<string>(maxLength: 14, nullable: false),
                    Tipo = table.Column<byte>(nullable: false),
                    SeguroSeguradoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguros_SeguroSegurado_SeguroSeguradoId",
                        column: x => x.SeguroSeguradoId,
                        principalTable: "SeguroSegurado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguros_SeguroSeguradoId",
                table: "Seguros",
                column: "SeguroSeguradoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeguroSegurado_ResidenciaId",
                table: "SeguroSegurado",
                column: "ResidenciaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeguroSegurado_VeiculoId",
                table: "SeguroSegurado",
                column: "VeiculoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeguroSegurado_VidaId",
                table: "SeguroSegurado",
                column: "VidaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguros");

            migrationBuilder.DropTable(
                name: "SeguroSegurado");

            migrationBuilder.DropTable(
                name: "Residencias");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Vidas");
        }
    }
}
