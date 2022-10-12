using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("TURNO")]
    public partial class TURNO
    {
        public TURNO()
        {
            EMPLEADOs = new HashSet<EMPLEADO>();
        }

        /// <summary>
        /// Identificador unico del turno 
        /// </summary>
        [Key]
        public int TurnoId { get; set; }
        /// <summary>
        /// Fecha correspondiente a turno
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime FechaTurno { get; set; }
        /// <summary>
        /// Hora correspondiente al ingreso
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime HoraIngreso { get; set; }
        /// <summary>
        /// Estado actual del turno
        /// </summary>
        public bool Estado { get; set; }
        /// <summary>
        /// Identificador unico del usuario
        /// </summary>
        public int AspNetUserId { get; set; }

        [InverseProperty("TURNO_Turno")]
        public virtual ICollection<EMPLEADO> EMPLEADOs { get; set; }
    }
}
