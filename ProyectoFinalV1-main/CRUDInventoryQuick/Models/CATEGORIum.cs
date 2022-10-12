using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("CATEGORIA")]
    public partial class CATEGORIum
    {
        public CATEGORIum()
        {
            SUBCATEGORIa = new HashSet<SUBCATEGORIum>();
        }

        /// <summary>
        /// Identificador unico de categoria
        /// </summary>
        [Key]
        public int CategoriaId { get; set; }
        /// <summary>
        /// Indica si la categoria se encuentra activa
        /// </summary>
        public bool Estado { get; set; }
        /// <summary>
        /// Indica el nombre de la categoria
        /// </summary>
        [StringLength(64)]
        public string Nombre { get; set; } = null!;

        [InverseProperty("Categoria")]
        public virtual ICollection<SUBCATEGORIum> SUBCATEGORIa { get; set; }
    }
}
