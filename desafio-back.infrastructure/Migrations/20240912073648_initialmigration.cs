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
                    identificador = table.Column<string>(type: "text", nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
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
                    identificador = table.Column<string>(type: "text", nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
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
                    nome = table.Column<string>(type: "text", nullable: true),
                    prazoemdias = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false),
                    multa_antecipacao = table.Column<decimal>(type: "numeric", nullable: false),
                    valordiaadicional = table.Column<decimal>(type: "numeric", nullable: false),
                    identificador = table.Column<string>(type: "text", nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_plano", x => x.internal_id);
                });

            migrationBuilder.CreateTable(
                name: "locacao",
                columns: table => new
                {
                    internal_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    identificador = table.Column<string>(type: "text", nullable: true),
                    entregador_id = table.Column<int>(type: "integer", nullable: false),
                    moto_id = table.Column<int>(type: "integer", nullable: false),
                    plan_id = table.Column<int>(type: "integer", nullable: false),
                    data_inicio = table.Column<DateTime>(type: "date", nullable: false),
                    data_termino = table.Column<DateTime>(type: "date", nullable: false),
                    data_previsao_termino = table.Column<DateTime>(type: "date", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_locacao", x => x.internal_id);
                    table.ForeignKey(
                        name: "fk_locacao_entregador_delivery_man_id",
                        column: x => x.entregador_id,
                        principalTable: "entregador",
                        principalColumn: "internal_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_locacao_moto_motorcycle_id",
                        column: x => x.moto_id,
                        principalTable: "moto",
                        principalColumn: "internal_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_locacao_plano_plan_id",
                        column: x => x.plan_id,
                        principalTable: "plano",
                        principalColumn: "internal_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "devolucao",
                columns: table => new
                {
                    internal_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rental_id = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    value = table.Column<decimal>(type: "decimal", nullable: false),
                    identificador = table.Column<string>(type: "text", nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_devolucao", x => x.internal_id);
                    table.ForeignKey(
                        name: "fk_devolucao_locacao_rental_id",
                        column: x => x.rental_id,
                        principalTable: "locacao",
                        principalColumn: "internal_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_devolucao_rental_id",
                table: "devolucao",
                column: "rental_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_entregador_cnpj",
                table: "entregador",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_entregador_numerocnh",
                table: "entregador",
                column: "numerocnh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_locacao_delivery_man_id",
                table: "locacao",
                column: "entregador_id");

            migrationBuilder.CreateIndex(
                name: "ix_locacao_motorcycle_id",
                table: "locacao",
                column: "moto_id");

            migrationBuilder.CreateIndex(
                name: "ix_locacao_plan_id",
                table: "locacao",
                column: "plan_id");

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
               columns: new[] { "identificador", "nome", "prazoemdias", "valor", "multa_antecipacao", "valordiaadicional" },
               values: new object[,]
               {
                 { "7", "Plano 7 Dias", 7, 30.00m, 0.2, 50  },
                 { "15", "Plano 15 Dias", 15, 28.00m, 0.4, 50 },
                 { "30", "Plano 30 Dias", 30, 22.00m, 0.6, 50 },
                 { "45", "Plano 45 Dias", 45, 20.00m, 0.8, 50 },
                 { "50", "Plano 50 Dias", 50, 18.00m, 0.9, 50 }
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "devolucao");

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
