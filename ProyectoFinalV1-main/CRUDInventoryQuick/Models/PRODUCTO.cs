using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("PRODUCTO")]
    public partial class PRODUCTO
    {
        public PRODUCTO()
        {
            DETALLEPEDIDOs = new HashSet<DETALLEPEDIDO>();
            IMAGENPRODUCTOs = new HashSet<IMAGENPRODUCTO>();
            PRECIOs = new HashSet<PRECIO>();
            STOCKs = new HashSet<STOCK>();
            TRANSACCIONs = new HashSet<TRANSACCION>();
            UNIDADMEDIDa = new HashSet<UNIDADMEDIDum>();
        }

        /// <summary>
        /// Identificador unico del producto
        /// </summary>
        [Key]
        public int ProductoId { get; set; }
        /// <summary>
        /// Indica el nombre del producto
        /// </summary>
        [StringLength(64)]
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Indica las caracteristicas que posee el producto
        /// </summary>
        [StringLength(64)]
        public string Descripcion { get; set; } = null!;
        /// <summary>
        /// Indica si el producto esta activo
        /// </summary>
        public bool Estado { get; set; }
        /// <summary>
        /// Identificador unico de la subcategoria
        /// </summary>
        public int SUBCATEGORIA_SubcategoriaId { get; set; }
        /// <summary>
        /// Identificador unico de la marca
        /// </summary>
        public int MARCA_MarcaId { get; set; }

        [ForeignKey("MARCA_MarcaId")]
        [InverseProperty("PRODUCTOs")]
        public virtual MARCA? Marca{ get; set; } = null;
        [ForeignKey("SUBCATEGORIA_SubcategoriaId")]
        [InverseProperty("PRODUCTOs")]
        public virtual SUBCATEGORIum? Subcategoria { get; set; } = null;
        [InverseProperty("PRODUCTO_Producto")]
        public virtual ICollection<DETALLEPEDIDO> DETALLEPEDIDOs { get; set; }
        [InverseProperty("PRODUCTO_Producto")]
        public virtual ICollection<IMAGENPRODUCTO> IMAGENPRODUCTOs { get; set; }
        [InverseProperty("Producto")]
        public virtual ICollection<PRECIO> PRECIOs { get; set; }
        [InverseProperty("PRODUCTO_Producto")]
        public virtual ICollection<STOCK> STOCKs { get; set; }
        [InverseProperty("PRODUCTO_Producto")]
        public virtual ICollection<TRANSACCION> TRANSACCIONs { get; set; }
        [InverseProperty("PRODUCTO_Producto")]
        public virtual ICollection<UNIDADMEDIDum> UNIDADMEDIDa { get; set; }
    }
}
