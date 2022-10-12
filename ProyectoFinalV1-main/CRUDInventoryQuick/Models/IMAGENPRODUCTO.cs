using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("IMAGENPRODUCTO")]
    public partial class IMAGENPRODUCTO
    {
        /// <summary>
        /// Identificador unico de la imagen producto 
        /// </summary>
        [Key]
        public int ImagenProductoId { get; set; }
        /// <summary>
        /// Indica como es el producto
        /// </summary>
        [Column(TypeName = "image")]
        public byte[] Foto { get; set; } = null!;
        /// <summary>
        /// Indica si la imagen se encuentra activa
        /// </summary>
        public bool Estado { get; set; }
        /// <summary>
        /// Identificador unico del producto
        /// </summary>
        public int PRODUCTO_ProductoId { get; set; }

        [ForeignKey("PRODUCTO_ProductoId")]
        [InverseProperty("IMAGENPRODUCTOs")]
        public virtual PRODUCTO PRODUCTO_Producto { get; set; } = null!;
    }
}
