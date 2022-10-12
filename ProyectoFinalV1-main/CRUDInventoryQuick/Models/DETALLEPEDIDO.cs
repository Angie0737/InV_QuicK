using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("DETALLEPEDIDO")]
    public partial class DETALLEPEDIDO
    {
        /// <summary>
        /// Identificador unico de detalle pedido
        /// </summary>
        [Key]
        public int DetallePedidoId { get; set; }
        /// <summary>
        /// Indica la cantidad a cumplir en el pedido
        /// </summary>
        public int Cantidad { get; set; }
        /// <summary>
        /// Indica el costo unitario del pedido
        /// </summary>
        [Column(TypeName = "decimal(5, 2)")]
        public decimal PrecioUnitario { get; set; }
        /// <summary>
        /// Identificador unico del producto
        /// </summary>
        public int PRODUCTO_ProductoId { get; set; }
        /// <summary>
        /// Identificador unico del pedido
        /// </summary>
        public int PEDIDO_PedidoId { get; set; }

        [ForeignKey("PEDIDO_PedidoId")]
        [InverseProperty("DETALLEPEDIDOs")]
        public virtual PEDIDO PEDIDO_Pedido { get; set; } = null!;
        [ForeignKey("PRODUCTO_ProductoId")]
        [InverseProperty("DETALLEPEDIDOs")]
        public virtual PRODUCTO PRODUCTO_Producto { get; set; } = null!;
    }
}
