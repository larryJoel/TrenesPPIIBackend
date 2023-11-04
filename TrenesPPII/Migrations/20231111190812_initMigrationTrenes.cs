using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrenesPPII.Migrations
{
    /// <inheritdoc />
    public partial class initMigrationTrenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Ticket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Desripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    cant_pasajeros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trenes__3214EC07B906F425", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CP = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TipoDocId = table.Column<int>(type: "int", nullable: true),
                    NroDocumento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TipoUsuario_Id = table.Column<int>(type: "int", nullable: true),
                    FechaIni = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaEdit = table.Column<DateTime>(type: "datetime", nullable: true),
                    IRol_Id = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario",
                        column: x => x.TipoUsuario_Id,
                        principalTable: "TipoUsuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Viaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora_sal = table.Column<DateTime>(type: "datetime", nullable: true),
                    Hora_llegada = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tren_Id = table.Column<int>(type: "int", nullable: true),
                    Origen = table.Column<int>(type: "int", nullable: true),
                    destino = table.Column<int>(type: "int", nullable: true),
                    Disponible = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Viaje__3214EC07CB644CBB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viaje_Estacion",
                        column: x => x.Origen,
                        principalTable: "Estacion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viaje_Estacion1",
                        column: x => x.destino,
                        principalTable: "Estacion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viaje_Trenes",
                        column: x => x.Tren_Id,
                        principalTable: "Trenes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "factura",
                columns: table => new
                {
                    id_factura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_emision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura", x => x.id_factura);
                    table.ForeignKey(
                        name: "FK_factura_Usuario_IdClienteId",
                        column: x => x.IdClienteId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    id_asiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_viaje = table.Column<int>(type: "int", nullable: true),
                    numero_asiento = table.Column<int>(type: "int", nullable: true),
                    disponible = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Asientos__14864B67FFF7022E", x => x.id_asiento);
                    table.ForeignKey(
                        name: "FK_Asientos_Viaje",
                        column: x => x.id_viaje,
                        principalTable: "Viaje",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaEdit = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaExpira = table.Column<DateTime>(type: "datetime", nullable: true),
                    EstadoTicket = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Metodo_Pago_Id = table.Column<int>(type: "int", nullable: true),
                    TipoTicket_Id = table.Column<int>(type: "int", nullable: true),
                    Viaje_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_MetodoPago",
                        column: x => x.Metodo_Pago_Id,
                        principalTable: "MetodoPago",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Tipo_Ticket",
                        column: x => x.TipoTicket_Id,
                        principalTable: "Tipo_Ticket",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Viaje",
                        column: x => x.Viaje_Id,
                        principalTable: "Viaje",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Facturas",
                columns: table => new
                {
                    Id_detalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_factura = table.Column<int>(type: "int", nullable: false),
                    Id_ticket = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio_unitario = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    IdFacturaFactid_factura = table.Column<int>(type: "int", nullable: true),
                    IdTicketFactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Facturas", x => x.Id_detalle);
                    table.ForeignKey(
                        name: "FK_Detalle_Facturas_Ticket_IdTicketFactId",
                        column: x => x.IdTicketFactId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Detalle_Facturas_factura_IdFacturaFactid_factura",
                        column: x => x.IdFacturaFactid_factura,
                        principalTable: "factura",
                        principalColumn: "id_factura");
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<int>(type: "int", nullable: true),
                    Ticket_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Ticket_Ticket",
                        column: x => x.Ticket_Id,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_Ticket_Usuario",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_id_viaje",
                table: "Asientos",
                column: "id_viaje");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Facturas_IdFacturaFactid_factura",
                table: "Detalle_Facturas",
                column: "IdFacturaFactid_factura");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Facturas_IdTicketFactId",
                table: "Detalle_Facturas",
                column: "IdTicketFactId");

            migrationBuilder.CreateIndex(
                name: "IX_factura_IdClienteId",
                table: "factura",
                column: "IdClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Metodo_Pago_Id",
                table: "Ticket",
                column: "Metodo_Pago_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TipoTicket_Id",
                table: "Ticket",
                column: "TipoTicket_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Viaje_Id",
                table: "Ticket",
                column: "Viaje_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuario_Id",
                table: "Usuario",
                column: "TipoUsuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Ticket_Ticket_Id",
                table: "Usuario_Ticket",
                column: "Ticket_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Ticket_Usuario_Id",
                table: "Usuario_Ticket",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_destino",
                table: "Viaje",
                column: "destino");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_Origen",
                table: "Viaje",
                column: "Origen");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_Tren_Id",
                table: "Viaje",
                column: "Tren_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Detalle_Facturas");

            migrationBuilder.DropTable(
                name: "Usuario_Ticket");

            migrationBuilder.DropTable(
                name: "factura");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "Tipo_Ticket");

            migrationBuilder.DropTable(
                name: "Viaje");

            migrationBuilder.DropTable(
                name: "TipoUsuario");

            migrationBuilder.DropTable(
                name: "Estacion");

            migrationBuilder.DropTable(
                name: "Trenes");
        }
    }
}
