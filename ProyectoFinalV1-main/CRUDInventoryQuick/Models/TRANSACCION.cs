using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("TRANSACCION")]
    public partial class TRANSACCION
    {
        /// <summary>
        /// Identificador unico de la transaccion
        /// </summary>
        [Key]
        public int TransacciónId { get; set; }
        /// <summary>
        /// Cantidad correspondiente al producto
        /// </summary>
        public int CantidadProducto { get; set; }
        /// <summary>
        /// Fecha correspondiente al producto
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime FechaTransaccion { get; set; }
        /// <summary>
        /// Otros detalles correspondiente a la transaccion
        /// </summary>
        [StringLength(64)]
        public string? OtrosDetalles { get; set; }
        /// <summary>
        /// Identificador unico de producto
        /// </summary>
        public int PRODUCTO_ProductoId { get; set; }
        /// <summary>
        /// Identificador unico correspondiente a tipos de transaccion
        /// </summary>
        public int TIPOSDETRANSACCIÓN_TipoTransaccionId { get; set; }

        [ForeignKey("PRODUCTO_ProductoId")]
        [InverseProperty("TRANSACCIONs")]
        public virtual PRODUCTO PRODUCTO_Producto { get; set; } = null!;
        [ForeignKey("TIPOSDETRANSACCIÓN_TipoTransaccionId")]
        [InverseProperty("TRANSACCIONs")]
        public virtual TIPOSDETRANSACCIÓN TIPOSDETRANSACCIÓN_TipoTransaccion { get; set; } = null!;
    }
}
