using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("MARCA")]
    public partial class MARCA
    {
        public MARCA()
        {
            PRODUCTOs = new HashSet<PRODUCTO>();
        }

        /// <summary>
        /// Identificador unico de marca
        /// </summary>
        [Key]
        public int MarcaId { get; set; }
        /// <summary>
        /// Indica el nombre de la marca
        /// </summary>
        [StringLength(64)]
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Indica si la marca esta activa
        /// </summary>
        public bool Estado { get; set; }

        [InverseProperty("Marca")]
        public virtual ICollection<PRODUCTO> PRODUCTOs { get; set; }
    }
}
