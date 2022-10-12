using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("SUELDO")]
    public partial class SUELDO
    {
        /// <summary>
        /// Identificador unico de sueldo
        /// </summary>
        [Key]
        public int SueldoId { get; set; }
        /// <summary>
        /// Indica la fecha de la contratacion
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime FechaContrato { get; set; }
        /// <summary>
        /// Indica la fecha finalizacion del contrato
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime FechaFinalizacion { get; set; }
        /// <summary>
        /// Indica las ganancias mensuales del empleado
        /// </summary>
        public long SueldoMensual { get; set; }
        /// <summary>
        /// Indica el tipo contrato
        /// </summary>
        [StringLength(64)]
        public string ObjetoContrato { get; set; } = null!;
        /// <summary>
        /// Indica el salario total del empleado
        /// </summary>
        public long SalarioTotal { get; set; }
        /// <summary>
        /// Indica si el sueldo esta activo
        /// </summary>
        public bool Estado { get; set; }
        /// <summary>
        /// Identificador unico de usuario
        /// </summary>
        [Column(TypeName = "numeric(28, 0)")]
        public decimal EMPLEADOS_ASPNETUSER_ASPNETUSER_ID { get; set; }

        [ForeignKey("EMPLEADOS_ASPNETUSER_ASPNETUSER_ID")]
        [InverseProperty("SUELDOs")]
        public virtual EMPLEADO EMPLEADOS_ASPNETUSER_ASPNETUSER { get; set; } = null!;
    }
}
