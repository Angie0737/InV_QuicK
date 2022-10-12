using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("LUGAR")]
    public partial class LUGAR
    {
        public LUGAR()
        {
            STOCKs = new HashSet<STOCK>();
        }

        /// <summary>
        /// Identificador unico del lugar 
        /// </summary>
        [Key]
        public int LugarId { get; set; }
        /// <summary>
        /// Indica la fecha ingreso del lugar
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime FechaIngreso { get; set; }
        /// <summary>
        /// Indica ubicacion del lugar
        /// </summary>
        [StringLength(64)]
        public string Direccion { get; set; } = null!;
        /// <summary>
        /// Indica metodo de comunicacion con el lugar
        /// </summary>
        [StringLength(64)]
        public string Correo { get; set; } = null!;
        /// <summary>
        /// Identificador unico de ciudad
        /// </summary>
        public int CIUDAD_CiudadId { get; set; }

        [ForeignKey("CIUDAD_CiudadId")]
        [InverseProperty("LUGARs")]
        public virtual CIUDAD CIUDAD_Ciudad { get; set; } = null!;
        [InverseProperty("LUGAR_Lugar")]
        public virtual ICollection<STOCK> STOCKs { get; set; }
    }
}
