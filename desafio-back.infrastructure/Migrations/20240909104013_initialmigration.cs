using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace desafio_back.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entregador",
                columns: table => new
                {
                    internal_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    datanascimento = table.Column<DateTime>(type: "date", nullable: false),
                    numerocnh = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    tipocnh = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    imagemcnh = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    identificador = table.Column<string>(type: "text", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_entregador", x => x.internal_id);
                });

            migrationBuilder.CreateTable(
                name: "moto",
                columns: table => new
                {
                    internal_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ano = table.Column<int>(type: "integer", nullable: false),
                    modelo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    placa = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    identificador = table.Column<string>(type: "text", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_moto", x => x.internal_id);
                });

            migrationBuilder.CreateTable(
                name: "plano",
                columns: table => new
                {
                    internal_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    prazodias = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false),
                    identificador = table.Column<string>(type: "text", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_plano", x => x.internal_id);
                });

            migrationBuilder.CreateTable(
                name: "locacao",
                columns: table => new
                {
                    internal_id = table.Column<int>(type: "integer", nullable: false),
                    entregador_id = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    moto_id = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    data_inicio = table.Column<DateTime>(type: "timestamp", nullable: false),
                    data_termino = table.Column<DateTime>(type: "timestamp", nullable: false),
                    data_previsao_termino = table.Column<DateTime>(type: "timestamp", nullable: false),
                    delivery_man_internal_id = table.Column<int>(type: "integer", nullable: true),
                    identificador = table.Column<string>(type: "text", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_locacao", x => x.internal_id);
                    table.ForeignKey(
                        name: "fk_locacao_entregador_delivery_man_internal_id",
                        column: x => x.delivery_man_internal_id,
                        principalTable: "entregador",
                        principalColumn: "internal_id");
                    table.ForeignKey(
                        name: "fk_locacao_entregador_internal_id",
                        column: x => x.internal_id,
                        principalTable: "entregador",
                        principalColumn: "internal_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_locacao_moto_internal_id",
                        column: x => x.internal_id,
                        principalTable: "moto",
                        principalColumn: "internal_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_locacao_plano_internal_id",
                        column: x => x.internal_id,
                        principalTable: "plano",
                        principalColumn: "internal_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_locacao_delivery_man_internal_id",
                table: "locacao",
                column: "delivery_man_internal_id");

            migrationBuilder.CreateIndex(
                name: "ix_moto_placa",
                table: "moto",
                column: "placa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_plano_identificador",
                table: "plano",
                column: "identificador",
                unique: true);

            migrationBuilder.InsertData(
               table: "plano",
               columns: new[] { "identificador", "nome", "prazodias", "valor" },
               values: new object[,]
               {
                 { "7", "Plano 7 Dias", 7, 30.00m },
                 { "15", "Plano 15 Dias", 15, 28.00m },
                 { "30",   "Plano 30 Dias", 30, 22.00m },
                 { "45", "Plano 45 Dias", 45, 20.00m },
                 { "50",  "Plano 50 Dias", 50, 18.00m }
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "locacao");

            migrationBuilder.DropTable(
                name: "entregador");

            migrationBuilder.DropTable(
                name: "moto");

            migrationBuilder.DropTable(
                name: "plano");
        }
    }
}
