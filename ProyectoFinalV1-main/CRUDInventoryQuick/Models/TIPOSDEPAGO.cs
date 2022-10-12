using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("TIPOSDEPAGO")]
    public partial class TIPOSDEPAGO
    {
        /// <summary>
        /// Identificador unico de tipos de pago
        /// </summary>
        [Key]
        public int TiposdePagoId { get; set; }
        /// <summary>
        /// Nombre del tipo de pago correspondiente
        /// </summary>
        [StringLength(64)]
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Indica si la categoria esta activa 
        /// </summary>
        public bool Estado { get; set; }
        /// <summary>
        /// Identificador unico de pedido
        /// </summary>
        public int PEDIDO_PedidoId { get; set; }

        [ForeignKey("PEDIDO_PedidoId")]
        [InverseProperty("TIPOSDEPAGOs")]
        public virtual PEDIDO PEDIDO_Pedido { get; set; } = null!;
    }
}
