using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CRUDInventoryQuick.Models;

namespace CRUDInventoryQuick.Datos
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ADMINISTRADOR> ADMINISTRADORs { get; set; } = null!;
        public virtual DbSet<ASPNETUSER> ASPNETUSERs { get; set; } = null!;
        public virtual DbSet<ASPNETUSERCLAIM> ASPNETUSERCLAIMs { get; set; } = null!;
        public virtual DbSet<ASPNETUSERLOGIN> ASPNETUSERLOGINs { get; set; } = null!;
        public virtual DbSet<ASPNETUSERROLE> ASPNETUSERROLEs { get; set; } = null!;
        public virtual DbSet<CAJERO> CAJEROs { get; set; } = null!;
        public virtual DbSet<CATEGORIum> CATEGORIAs { get; set; } = null!;
        public virtual DbSet<CIUDAD> CIUDADs { get; set; } = null!;
        public virtual DbSet<CLIENTE> CLIENTEs { get; set; } = null!;
        public virtual DbSet<DETALLEPEDIDO> DETALLEPEDIDOs { get; set; } = null!;
        public virtual DbSet<EMPLEADO> EMPLEADOs { get; set; } = null!;
        public virtual DbSet<IMAGENPRODUCTO> IMAGENPRODUCTOs { get; set; } = null!;
        public virtual DbSet<LUGAR> LUGARs { get; set; } = null!;
        public virtual DbSet<MARCA> MARCAs { get; set; } = null!;
        public virtual DbSet<PEDIDO> PEDIDOs { get; set; } = null!;
        public virtual DbSet<PRECIO> PRECIOs { get; set; } = null!;
        public virtual DbSet<PRODUCTO> PRODUCTOs { get; set; } = null!;
        public virtual DbSet<STOCK> STOCKs { get; set; } = null!;
        public virtual DbSet<SUBCATEGORIum> SUBCATEGORIAs { get; set; } = null!;
        public virtual DbSet<SUELDO> SUELDOs { get; set; } = null!;
        public virtual DbSet<TIPOSDEPAGO> TIPOSDEPAGOs { get; set; } = null!;
        public virtual DbSet<TIPOSDETRANSACCIÓN> TIPOSDETRANSACCIÓNs { get; set; } = null!;
        public virtual DbSet<TRANSACCION> TRANSACCIONs { get; set; } = null!;
        public virtual DbSet<TURNO> TURNOs { get; set; } = null!;
        public virtual DbSet<UNIDADMEDIDum> UNIDADMEDIDAs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8Q0854J;Database=Inventario;User ID=sa;Password=yenersito20");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMINISTRADOR>(entity =>
            {
                entity.HasKey(e => e.ASPNETUSER_ASPNETUSER_ID)
                    .HasName("ADMINISTRADOR_PK");

                entity.Property(e => e.ASPNETUSER_ASPNETUSER_ID).HasComment("Identificador Unico de cada Usuario");

                entity.HasOne(d => d.ASPNETUSER_ASPNETUSER)
                    .WithOne(p => p.ADMINISTRADOR)
                    .HasForeignKey<ADMINISTRADOR>(d => d.ASPNETUSER_ASPNETUSER_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ADMINISTRADOR_ASPNETUSER_FK");
            });

            modelBuilder.Entity<ASPNETUSER>(entity =>
            {
                entity.HasKey(e => e.ASPNETUSER_ID)
                    .HasName("ASPNETUSER_PK");

                entity.Property(e => e.ASPNETUSER_ID)
                    .ValueGeneratedOnAdd()
                    .HasComment("Identificador unico de usuario");

                entity.Property(e => e.AccesoDenegado).HasComment("Indica si el aceeso ha sido denegado");

                entity.Property(e => e.Apellidos).HasComment("Indica apellidos de la persona");

                entity.Property(e => e.Contrasena).HasComment("Indica la contraseña de usuario");

                entity.Property(e => e.Correo).HasComment("Indica el correo del usuario");

                entity.Property(e => e.CorreoConfirmado).HasComment("Indica si el correo ha sido confirmado");

                entity.Property(e => e.Direccion).HasComment("Indica dirección de usuario");

                entity.Property(e => e.DosFactoresDisponibles)
                    .IsFixedLength()
                    .HasComment("Indica factores disponibles");

                entity.Property(e => e.FechaAbierta).HasComment("Indica fecha abierta usuario");

                entity.Property(e => e.FechaCierre).HasComment("Indica fecha cierre usuario");

                entity.Property(e => e.FechaNacimiento).HasComment("Indica fecha de nacimiento de usuario");

                entity.Property(e => e.NombreNetUserId).HasComment("Indica el nombre del usuario");

                entity.Property(e => e.Nombres).HasComment("Indica nombre de la persona");

                entity.Property(e => e.ReclamarTelefono).HasComment("Indica el reclamo de telefono usuario");

                entity.Property(e => e.SelloDeSeguridad).HasComment("Indica el sello de seguridad del usuario");

                entity.Property(e => e.Telefono).HasComment("Indica telefono de usuario");

                entity.HasMany(d => d.ASPNETUSERROLE_AspNetRoles)
                    .WithMany(p => p.ASPNETUSER_ASPNETUSERs)
                    .UsingEntity<Dictionary<string, object>>(
                        "ASPNETUSER_ASPNETUSERROLE",
                        l => l.HasOne<ASPNETUSERROLE>().WithMany().HasForeignKey("ASPNETUSERROLE_AspNetRoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("ASPNETUSER_ASPNETUSERROLE_ASPNETUSERROLE_FK"),
                        r => r.HasOne<ASPNETUSER>().WithMany().HasForeignKey("ASPNETUSER_ASPNETUSER_ID").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("ASPNETUSER_ASPNETUSERROLE_ASPNETUSER_FK"),
                        j =>
                        {
                            j.HasKey("ASPNETUSER_ASPNETUSER_ID", "ASPNETUSERROLE_AspNetRoleId").HasName("ASPNETUSER_ASPNETUSERROLE_PK");

                            j.ToTable("ASPNETUSER_ASPNETUSERROLE");

                            j.IndexerProperty<decimal>("ASPNETUSER_ASPNETUSER_ID").HasColumnType("numeric(28, 0)").HasComment("Identificador unico de usuario");

                            j.IndexerProperty<int>("ASPNETUSERROLE_AspNetRoleId").HasComment("Identificador unico de rol");
                        });
            });

            modelBuilder.Entity<ASPNETUSERCLAIM>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de llave");

                entity.Property(e => e.ASPNETUSER_ASPNETUSER_ID).HasComment("Identificador unico de usuario");

                entity.Property(e => e.AspNetUserId).HasComment("Identificador unico del usuario");

                entity.Property(e => e.ClaimType).HasComment("Indica el tipo de llave");

                entity.Property(e => e.ClaimValue).HasComment("Indica el valor de la llave");

                entity.HasOne(d => d.ASPNETUSER_ASPNETUSER)
                    .WithMany(p => p.ASPNETUSERCLAIMs)
                    .HasForeignKey(d => d.ASPNETUSER_ASPNETUSER_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ASPNETUSERCLAIM_ASPNETUSER_FK");
            });

            modelBuilder.Entity<ASPNETUSERLOGIN>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de ingresar");

                entity.Property(e => e.ASPNETUSER_ASPNETUSER_ID).HasComment("Identificador unico de usuario");

                entity.Property(e => e.LoginProvider).HasComment("Indica ingreso");

                entity.Property(e => e.ProviderKey).HasComment("Indica llave");

                entity.HasOne(d => d.ASPNETUSER_ASPNETUSER)
                    .WithMany(p => p.ASPNETUSERLOGINs)
                    .HasForeignKey(d => d.ASPNETUSER_ASPNETUSER_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ASPNETUSERLOGIN_ASPNETUSER_FK");
            });

            modelBuilder.Entity<ASPNETUSERROLE>(entity =>
            {
                entity.HasKey(e => e.AspNetRoleId)
                    .HasName("ASPNETUSERROLE_PK");

                entity.Property(e => e.AspNetRoleId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de Rol");

                entity.Property(e => e.Nombre).HasComment("Indica el nombre del rol correspondiente");
            });

            modelBuilder.Entity<CAJERO>(entity =>
            {
                entity.HasKey(e => e.ASPNETUSER_ASPNETUSER_ID)
                    .HasName("CAJEROS_PK");

                entity.Property(e => e.ASPNETUSER_ASPNETUSER_ID).HasComment("Identificador unico de usuario cajero");

                entity.HasOne(d => d.ASPNETUSER_ASPNETUSER)
                    .WithOne(p => p.CAJERO)
                    .HasForeignKey<CAJERO>(d => d.ASPNETUSER_ASPNETUSER_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CAJEROS_ASPNETUSER_FK");
            });

            modelBuilder.Entity<CATEGORIum>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("CATEGORIA_PK");

                entity.Property(e => e.CategoriaId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de categoria");

                entity.Property(e => e.Estado).HasComment("Indica si la categoria se encuentra activa");

                entity.Property(e => e.Nombre).HasComment("Indica el nombre de la categoria");
            });

            modelBuilder.Entity<CIUDAD>(entity =>
            {
                entity.Property(e => e.CiudadId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de ciudad");

                entity.Property(e => e.Nombre).HasComment("Indica el nombre de la ciudad en donde se encuentra el local");
            });

            modelBuilder.Entity<CLIENTE>(entity =>
            {
                entity.HasKey(e => e.ASPNETUSER_ASPNETUSER_ID)
                    .HasName("CLIENTES_PK");

                entity.Property(e => e.ASPNETUSER_ASPNETUSER_ID).HasComment("Identificador unico de usuario clientes");

                entity.HasOne(d => d.ASPNETUSER_ASPNETUSER)
                    .WithOne(p => p.CLIENTE)
                    .HasForeignKey<CLIENTE>(d => d.ASPNETUSER_ASPNETUSER_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CLIENTES_ASPNETUSER_FK");
            });

            modelBuilder.Entity<DETALLEPEDIDO>(entity =>
            {
                entity.Property(e => e.DetallePedidoId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de detalle pedido");

                entity.Property(e => e.Cantidad).HasComment("Indica la cantidad a cumplir en el pedido");

                entity.Property(e => e.PEDIDO_PedidoId).HasComment("Identificador unico del pedido");

                entity.Property(e => e.PRODUCTO_ProductoId).HasComment("Identificador unico del producto");

                entity.Property(e => e.PrecioUnitario).HasComment("Indica el costo unitario del pedido");

                entity.HasOne(d => d.PEDIDO_Pedido)
                    .WithMany(p => p.DETALLEPEDIDOs)
                    .HasForeignKey(d => d.PEDIDO_PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DETALLEPEDIDO_PEDIDO_FK");

                entity.HasOne(d => d.PRODUCTO_Producto)
                    .WithMany(p => p.DETALLEPEDIDOs)
                    .HasForeignKey(d => d.PRODUCTO_ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DETALLEPEDIDO_PRODUCTO_FK");
            });

            modelBuilder.Entity<EMPLEADO>(entity =>
            {
                entity.HasKey(e => e.ASPNETUSER_ASPNETUSER_ID)
                    .HasName("EMPLEADOS_PK");

                entity.Property(e => e.ASPNETUSER_ASPNETUSER_ID).HasComment("Identificador unico de usuario empleado");

                entity.Property(e => e.TURNO_TurnoId).HasComment("Identificador unico de turno");

                entity.HasOne(d => d.ASPNETUSER_ASPNETUSER)
                    .WithOne(p => p.EMPLEADO)
                    .HasForeignKey<EMPLEADO>(d => d.ASPNETUSER_ASPNETUSER_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMPLEADOS_ASPNETUSER_FK");

                entity.HasOne(d => d.TURNO_Turno)
                    .WithMany(p => p.EMPLEADOs)
                    .HasForeignKey(d => d.TURNO_TurnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMPLEADOS_TURNO_FK");
            });

            modelBuilder.Entity<IMAGENPRODUCTO>(entity =>
            {
                entity.Property(e => e.ImagenProductoId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de la imagen producto ");

                entity.Property(e => e.Estado).HasComment("Indica si la imagen se encuentra activa");

                entity.Property(e => e.Foto).HasComment("Indica como es el producto");

                entity.Property(e => e.PRODUCTO_ProductoId).HasComment("Identificador unico del producto");

                entity.HasOne(d => d.PRODUCTO_Producto)
                    .WithMany(p => p.IMAGENPRODUCTOs)
                    .HasForeignKey(d => d.PRODUCTO_ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IMAGENPRODUCTO_PRODUCTO_FK");
            });

            modelBuilder.Entity<LUGAR>(entity =>
            {
                entity.Property(e => e.LugarId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico del lugar ");

                entity.Property(e => e.CIUDAD_CiudadId).HasComment("Identificador unico de ciudad");

                entity.Property(e => e.Correo).HasComment("Indica metodo de comunicacion con el lugar");

                entity.Property(e => e.Direccion).HasComment("Indica ubicacion del lugar");

                entity.Property(e => e.FechaIngreso).HasComment("Indica la fecha ingreso del lugar");

                entity.HasOne(d => d.CIUDAD_Ciudad)
                    .WithMany(p => p.LUGARs)
                    .HasForeignKey(d => d.CIUDAD_CiudadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LUGAR_CIUDAD_FK");
            });

            modelBuilder.Entity<MARCA>(entity =>
            {
                entity.Property(e => e.MarcaId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de marca");

                entity.Property(e => e.Estado).HasComment("Indica si la marca esta activa");

                entity.Property(e => e.Nombre).HasComment("Indica el nombre de la marca");
            });

            modelBuilder.Entity<PEDIDO>(entity =>
            {
                entity.Property(e => e.PedidoId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de pedido");

                entity.Property(e => e.Estado).HasComment("Indica si el pedido esta activo");

                entity.Property(e => e.Fecha).HasComment("Indica la fecha en la que se realizo el pedido");

                entity.Property(e => e.Nombre).HasComment("Indica el nombre del pedido");
            });

            modelBuilder.Entity<PRECIO>(entity =>
            {
                entity.Property(e => e.PrecioId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico del precio");

                entity.Property(e => e.Descuento).HasComment("Indica un posible descuento que el producto pueda poseer");

                entity.Property(e => e.FechaIngreso).HasComment("Indica la fecha ingreso del precio");

                entity.Property(e => e.PRODUCTO_ProductoId).HasComment("Identificador unico del producto");

                entity.Property(e => e.PrecioCompra).HasComment("Indica el precio compra del producto");

                entity.Property(e => e.PrecioVentaFinal).HasComment("Indica el precio venta final");

                entity.Property(e => e.PrecioVentaInicial).HasComment("Indica el precio venta incial ");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.PRECIOs)
                    .HasForeignKey(d => d.PRODUCTO_ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRECIO_PRODUCTO_FK");
            });

            modelBuilder.Entity<PRODUCTO>(entity =>
            {
                entity.Property(e => e.ProductoId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico del producto");

                entity.Property(e => e.Descripcion).HasComment("Indica las caracteristicas que posee el producto");

                entity.Property(e => e.Estado).HasComment("Indica si el producto esta activo");

                entity.Property(e => e.MARCA_MarcaId).HasComment("Identificador unico de la marca");

                entity.Property(e => e.Nombre).HasComment("Indica el nombre del producto");

                entity.Property(e => e.SUBCATEGORIA_SubcategoriaId).HasComment("Identificador unico de la subcategoria");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.PRODUCTOs)
                    .HasForeignKey(d => d.MARCA_MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRODUCTO_MARCA_FK");

                entity.HasOne(d => d.Subcategoria)
                    .WithMany(p => p.PRODUCTOs)
                    .HasForeignKey(d => d.SUBCATEGORIA_SubcategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRODUCTO_SUBCATEGORIA_FK");
            });

            modelBuilder.Entity<STOCK>(entity =>
            {
                entity.Property(e => e.StockId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico del stock");

                entity.Property(e => e.CantidadStockAlarma).HasComment("Indica la cantidad alarma a tener en el stock");

                entity.Property(e => e.CantidadStockIdeal).HasComment("Indica la cantidad ideal a tener en el stock");

                entity.Property(e => e.CantidadStockReal).HasComment("Indica la cantidad real que se posee");

                entity.Property(e => e.FechaIngresoStock).HasComment("Indica la fecha ingreso del stock");

                entity.Property(e => e.LUGAR_LugarId).HasComment("Identificador unico del lugar");

                entity.Property(e => e.PRODUCTO_ProductoId).HasComment("Identificador unico del producto");

                entity.HasOne(d => d.LUGAR_Lugar)
                    .WithMany(p => p.STOCKs)
                    .HasForeignKey(d => d.LUGAR_LugarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("STOCK_LUGAR_FK");

                entity.HasOne(d => d.PRODUCTO_Producto)
                    .WithMany(p => p.STOCKs)
                    .HasForeignKey(d => d.PRODUCTO_ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("STOCK_PRODUCTO_FK");
            });

            modelBuilder.Entity<SUBCATEGORIum>(entity =>
            {
                entity.HasKey(e => e.SubcategoriaId)
                    .HasName("SUBCATEGORIA_PK");

                entity.Property(e => e.SubcategoriaId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de la subactegoria");

                entity.Property(e => e.CATEGORIA_CategoriaId).HasComment("Identificador unico de la categoria");

                entity.Property(e => e.Estado).HasComment("Indica si la categoria esta activa ");

                entity.Property(e => e.Nombre).HasComment("Indica el nombre de la categoria");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.SUBCATEGORIa)
                    .HasForeignKey(d => d.CATEGORIA_CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SUBCATEGORIA_CATEGORIA_FK");
            });

            modelBuilder.Entity<SUELDO>(entity =>
            {
                entity.Property(e => e.SueldoId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de sueldo");

                entity.Property(e => e.EMPLEADOS_ASPNETUSER_ASPNETUSER_ID).HasComment("Identificador unico de usuario");

                entity.Property(e => e.Estado).HasComment("Indica si el sueldo esta activo");

                entity.Property(e => e.FechaContrato).HasComment("Indica la fecha de la contratacion");

                entity.Property(e => e.FechaFinalizacion).HasComment("Indica la fecha finalizacion del contrato");

                entity.Property(e => e.ObjetoContrato).HasComment("Indica el tipo contrato");

                entity.Property(e => e.SalarioTotal).HasComment("Indica el salario total del empleado");

                entity.Property(e => e.SueldoMensual).HasComment("Indica las ganancias mensuales del empleado");

                entity.HasOne(d => d.EMPLEADOS_ASPNETUSER_ASPNETUSER)
                    .WithMany(p => p.SUELDOs)
                    .HasForeignKey(d => d.EMPLEADOS_ASPNETUSER_ASPNETUSER_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SUELDO_EMPLEADOS_FK");
            });

            modelBuilder.Entity<TIPOSDEPAGO>(entity =>
            {
                entity.Property(e => e.TiposdePagoId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de tipos de pago");

                entity.Property(e => e.Estado).HasComment("Indica si la categoria esta activa ");

                entity.Property(e => e.Nombre).HasComment("Nombre del tipo de pago correspondiente");

                entity.Property(e => e.PEDIDO_PedidoId).HasComment("Identificador unico de pedido");

                entity.HasOne(d => d.PEDIDO_Pedido)
                    .WithMany(p => p.TIPOSDEPAGOs)
                    .HasForeignKey(d => d.PEDIDO_PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPOSDEPAGO_PEDIDO_FK");
            });

            modelBuilder.Entity<TIPOSDETRANSACCIÓN>(entity =>
            {
                entity.HasKey(e => e.TipoTransaccionId)
                    .HasName("TIPOSDETRANSACCIÓN_PK");

                entity.Property(e => e.TipoTransaccionId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de tipos transaccion");

                entity.Property(e => e.Descripcion).HasComment("Descripcion correspondiente al tipo de transaccion");
            });

            modelBuilder.Entity<TRANSACCION>(entity =>
            {
                entity.HasKey(e => e.TransacciónId)
                    .HasName("TRANSACCION_PK");

                entity.Property(e => e.TransacciónId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de la transaccion");

                entity.Property(e => e.CantidadProducto).HasComment("Cantidad correspondiente al producto");

                entity.Property(e => e.FechaTransaccion).HasComment("Fecha correspondiente al producto");

                entity.Property(e => e.OtrosDetalles).HasComment("Otros detalles correspondiente a la transaccion");

                entity.Property(e => e.PRODUCTO_ProductoId).HasComment("Identificador unico de producto");

                entity.Property(e => e.TIPOSDETRANSACCIÓN_TipoTransaccionId).HasComment("Identificador unico correspondiente a tipos de transaccion");

                entity.HasOne(d => d.PRODUCTO_Producto)
                    .WithMany(p => p.TRANSACCIONs)
                    .HasForeignKey(d => d.PRODUCTO_ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRANSACCION_PRODUCTO_FK");

                entity.HasOne(d => d.TIPOSDETRANSACCIÓN_TipoTransaccion)
                    .WithMany(p => p.TRANSACCIONs)
                    .HasForeignKey(d => d.TIPOSDETRANSACCIÓN_TipoTransaccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRANSACCION_TIPOSDETRANSACCIÓN_FK");
            });

            modelBuilder.Entity<TURNO>(entity =>
            {
                entity.Property(e => e.TurnoId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico del turno ");

                entity.Property(e => e.AspNetUserId).HasComment("Identificador unico del usuario");

                entity.Property(e => e.Estado).HasComment("Estado actual del turno");

                entity.Property(e => e.FechaTurno).HasComment("Fecha correspondiente a turno");

                entity.Property(e => e.HoraIngreso).HasComment("Hora correspondiente al ingreso");
            });

            modelBuilder.Entity<UNIDADMEDIDum>(entity =>
            {
                entity.HasKey(e => e.UnidadMedidaId)
                    .HasName("UNIDADMEDIDA_PK");

                entity.Property(e => e.UnidadMedidaId)
                    .ValueGeneratedNever()
                    .HasComment("Identificador unico de cada medida");

                entity.Property(e => e.Estado).HasComment("Estado actual de la medida");

                entity.Property(e => e.Nombre).HasComment("Nombre de la medida");

                entity.Property(e => e.PRODUCTO_ProductoId).HasComment("Identificador unico del producto");

                entity.HasOne(d => d.PRODUCTO_Producto)
                    .WithMany(p => p.UNIDADMEDIDa)
                    .HasForeignKey(d => d.PRODUCTO_ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UNIDADMEDIDA_PRODUCTO_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
