using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dosen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nama_Dosen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mahasiswa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nama_Mhs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tgl_Lhr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisKelamin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahasiswa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MataKuliah",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kode_MK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nama_MK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MataKuliah", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perkuliahan",
                columns: table => new
                {
                    PerkuliahanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DosenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MahasiswaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MataKuliahId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perkuliahan", x => x.PerkuliahanId);
                    table.ForeignKey(
                        name: "FK_Perkuliahan_Dosen_DosenId",
                        column: x => x.DosenId,
                        principalTable: "Dosen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perkuliahan_Mahasiswa_MahasiswaId",
                        column: x => x.MahasiswaId,
                        principalTable: "Mahasiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perkuliahan_MataKuliah_MataKuliahId",
                        column: x => x.MataKuliahId,
                        principalTable: "MataKuliah",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perkuliahan_DosenId",
                table: "Perkuliahan",
                column: "DosenId");

            migrationBuilder.CreateIndex(
                name: "IX_Perkuliahan_MahasiswaId",
                table: "Perkuliahan",
                column: "MahasiswaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perkuliahan_MataKuliahId",
                table: "Perkuliahan",
                column: "MataKuliahId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perkuliahan");

            migrationBuilder.DropTable(
                name: "Dosen");

            migrationBuilder.DropTable(
                name: "Mahasiswa");

            migrationBuilder.DropTable(
                name: "MataKuliah");
        }
    }
}
