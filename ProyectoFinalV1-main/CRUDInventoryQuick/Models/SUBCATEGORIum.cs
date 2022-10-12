using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("SUBCATEGORIA")]
    public partial class SUBCATEGORIum
    {
        public SUBCATEGORIum()
        {
            PRODUCTOs = new HashSet<PRODUCTO>();
        }

        /// <summary>
        /// Identificador unico de la subactegoria
        /// </summary>
        [Key]
        public int SubcategoriaId { get; set; }
        /// <summary>
        /// Indica el nombre de la categoria
        /// </summary>
        [StringLength(64)]
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Indica si la categoria esta activa 
        /// </summary>
        public bool Estado { get; set; }
        /// <summary>
        /// Identificador unico de la categoria
        /// </summary>
        public int CATEGORIA_CategoriaId { get; set; }

        [ForeignKey("CATEGORIA_CategoriaId")]
        [InverseProperty("SUBCATEGORIa")]
        public virtual CATEGORIum? Categoria { get; set; } = null!;
        [InverseProperty("Subcategoria")]
        public virtual ICollection<PRODUCTO> PRODUCTOs { get; set; }
    }
}
