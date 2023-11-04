using TrenesPPII.Models;
using Microsoft.EntityFrameworkCore;
using TrenesPPII.Controllers;

namespace TrenesPPII.data
{
    public class TrenesContext: DbContext
    {
        public virtual DbSet<Asiento> Asientos { get; set; }

        public virtual DbSet<Estacion> Estacions { get; set; }

        public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<TipoTicket> TipoTickets { get; set; }

        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

        public virtual DbSet<Trene> Trenes { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<UsuarioTicket> UsuarioTickets { get; set; }

        public virtual DbSet<Viaje> Viajes { get; set; }

        public virtual DbSet<spPuestosDisponibles> PuestosDisponibles { get; set; }

        public TrenesContext(DbContextOptions<TrenesContext> options)
        : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asiento>(entity =>
            {
                entity.HasKey(e => e.IdAsiento).HasName("PK__Asientos__14864B67FFF7022E");

                entity.Property(e => e.IdAsiento).HasColumnName("id_asiento");
                entity.Property(e => e.Disponible).HasColumnName("disponible");
                entity.Property(e => e.IdViaje).HasColumnName("id_viaje");
                entity.Property(e => e.NumeroAsiento).HasColumnName("numero_asiento");

                entity.HasOne(d => d.IdViajeNavigation).WithMany(p => p.Asientos)
                    .HasForeignKey(d => d.IdViaje)
                    .HasConstraintName("FK_Asientos_Viaje");
            });

            modelBuilder.Entity<Estacion>(entity =>
            {
                entity.ToTable("Estacion");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.ToTable("MetodoPago");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.EstadoTicket)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.FechaCreate).HasColumnType("datetime");
                entity.Property(e => e.FechaEdit).HasColumnType("datetime");
                entity.Property(e => e.FechaExpira).HasColumnType("datetime");
                entity.Property(e => e.MetodoPagoId).HasColumnName("Metodo_Pago_Id");
                entity.Property(e => e.TipoTicketId).HasColumnName("TipoTicket_Id");
                entity.Property(e => e.ViajeId).HasColumnName("Viaje_Id");

                entity.HasOne(d => d.MetodoPago).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.MetodoPagoId)
                    .HasConstraintName("FK_Ticket_MetodoPago");

                entity.HasOne(d => d.TipoTicket).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TipoTicketId)
                    .HasConstraintName("FK_Ticket_Tipo_Ticket");

                entity.HasOne(d => d.Viaje).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ViajeId)
                    .HasConstraintName("FK_Ticket_Viaje");
            });

            modelBuilder.Entity<TipoTicket>(entity =>
            {
                entity.ToTable("Tipo_Ticket");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TipoUsuario");

                entity.Property(e => e.Desripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trene>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Trenes__3214EC07B906F425");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Cp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CP");
                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.FechaEdit).HasColumnType("datetime");
                entity.Property(e => e.FechaIni).HasColumnType("datetime");
                entity.Property(e => e.IrolId).HasColumnName("IRol_Id");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.NroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TipoUsuarioId).HasColumnName("TipoUsuario_Id");

                entity.HasOne(d => d.TipoUsuario).WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .HasConstraintName("FK_Usuario_TipoUsuario");
            });

            modelBuilder.Entity<UsuarioTicket>(entity =>
            {
                entity.ToTable("Usuario_Ticket");

                entity.Property(e => e.TicketId).HasColumnName("Ticket_Id");
                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

                entity.HasOne(d => d.Ticket).WithMany(p => p.UsuarioTickets)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_Usuario_Ticket_Ticket");

                entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioTickets)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Usuario_Ticket_Usuario");
            });

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Viaje__3214EC07CB644CBB");

                entity.ToTable("Viaje");

                entity.Property(e => e.Destino).HasColumnName("destino");
                entity.Property(e => e.HoraLlegada)
                    .HasColumnType("datetime")
                    .HasColumnName("Hora_llegada");
                entity.Property(e => e.HoraSal)
                    .HasColumnType("datetime")
                    .HasColumnName("Hora_sal");
                entity.Property(e => e.TrenId).HasColumnName("Tren_Id");

                entity.HasOne(d => d.DestinoNavigation).WithMany(p => p.ViajeDestinoNavigations)
                    .HasForeignKey(d => d.Destino)
                    .HasConstraintName("FK_Viaje_Estacion1");

                entity.HasOne(d => d.OrigenNavigation).WithMany(p => p.ViajeOrigenNavigations)
                    .HasForeignKey(d => d.Origen)
                    .HasConstraintName("FK_Viaje_Estacion");

                entity.HasOne(d => d.Tren).WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.TrenId)
                    .HasConstraintName("FK_Viaje_Trenes");
            });

            //OnModelCreatingPartial(modelBuilder);
        }
    }
}
