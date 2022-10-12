using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("UNIDADMEDIDA")]
    public partial class UNIDADMEDIDum
    {
        /// <summary>
        /// Identificador unico de cada medida
        /// </summary>
        [Key]
        public int UnidadMedidaId { get; set; }
        /// <summary>
        /// Nombre de la medida
        /// </summary>
        [StringLength(64)]
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Estado actual de la medida
        /// </summary>
        public bool Estado { get; set; }
        /// <summary>
        /// Identificador unico del producto
        /// </summary>
        public int PRODUCTO_ProductoId { get; set; }

        [ForeignKey("PRODUCTO_ProductoId")]
        [InverseProperty("UNIDADMEDIDa")]
        public virtual PRODUCTO PRODUCTO_Producto { get; set; } = null!;
    }
}
