using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("PEDIDO")]
    public partial class PEDIDO
    {
        public PEDIDO()
        {
            DETALLEPEDIDOs = new HashSet<DETALLEPEDIDO>();
            TIPOSDEPAGOs = new HashSet<TIPOSDEPAGO>();
        }

        /// <summary>
        /// Identificador unico de pedido
        /// </summary>
        [Key]
        public int PedidoId { get; set; }
        /// <summary>
        /// Indica la fecha en la que se realizo el pedido
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Indica el nombre del pedido
        /// </summary>
        [StringLength(64)]
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Indica si el pedido esta activo
        /// </summary>
        public bool Estado { get; set; }

        [InverseProperty("PEDIDO_Pedido")]
        public virtual ICollection<DETALLEPEDIDO> DETALLEPEDIDOs { get; set; }
        [InverseProperty("PEDIDO_Pedido")]
        public virtual ICollection<TIPOSDEPAGO> TIPOSDEPAGOs { get; set; }
    }
}
