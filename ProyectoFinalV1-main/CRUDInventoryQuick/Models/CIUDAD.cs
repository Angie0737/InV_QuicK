using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("CIUDAD")]
    public partial class CIUDAD
    {
        public CIUDAD()
        {
            LUGARs = new HashSet<LUGAR>();
        }

        /// <summary>
        /// Identificador unico de ciudad
        /// </summary>
        [Key]
        public int CiudadId { get; set; }
        /// <summary>
        /// Indica el nombre de la ciudad en donde se encuentra el local
        /// </summary>
        [StringLength(64)]
        public string Nombre { get; set; } = null!;

        [InverseProperty("CIUDAD_Ciudad")]
        public virtual ICollection<LUGAR> LUGARs { get; set; }
    }
}
