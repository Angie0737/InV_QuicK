using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("TIPOSDETRANSACCIÓN")]
    public partial class TIPOSDETRANSACCIÓN
    {
        public TIPOSDETRANSACCIÓN()
        {
            TRANSACCIONs = new HashSet<TRANSACCION>();
        }

        /// <summary>
        /// Identificador unico de tipos transaccion
        /// </summary>
        [Key]
        public int TipoTransaccionId { get; set; }
        /// <summary>
        /// Descripcion correspondiente al tipo de transaccion
        /// </summary>
        [StringLength(64)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("TIPOSDETRANSACCIÓN_TipoTransaccion")]
        public virtual ICollection<TRANSACCION> TRANSACCIONs { get; set; }
    }
}
