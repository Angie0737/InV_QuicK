using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("STOCK")]
    public partial class STOCK
    {
        /// <summary>
        /// Identificador unico del stock
        /// </summary>
        [Key]
        public int StockId { get; set; }
        /// <summary>
        /// Indica la fecha ingreso del stock
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime FechaIngresoStock { get; set; }
        /// <summary>
        /// Indica la cantidad ideal a tener en el stock
        /// </summary>
        public int CantidadStockIdeal { get; set; }
        /// <summary>
        /// Indica la cantidad alarma a tener en el stock
        /// </summary>
        public int CantidadStockAlarma { get; set; }
        /// <summary>
        /// Indica la cantidad real que se posee
        /// </summary>
        public int CantidadStockReal { get; set; }
        /// <summary>
        /// Identificador unico del producto
        /// </summary>
        public int PRODUCTO_ProductoId { get; set; }
        /// <summary>
        /// Identificador unico del lugar
        /// </summary>
        public int LUGAR_LugarId { get; set; }

        [ForeignKey("LUGAR_LugarId")]
        [InverseProperty("STOCKs")]
        public virtual LUGAR LUGAR_Lugar { get; set; } = null!;
        [ForeignKey("PRODUCTO_ProductoId")]
        [InverseProperty("STOCKs")]
        public virtual PRODUCTO PRODUCTO_Producto { get; set; } = null!;
    }
}
