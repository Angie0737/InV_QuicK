using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("CLIENTES")]
    public partial class CLIENTE
    {
        /// <summary>
        /// Identificador unico de usuario clientes
        /// </summary>
        [Key]
        [Column(TypeName = "numeric(28, 0)")]
        public decimal ASPNETUSER_ASPNETUSER_ID { get; set; }

        [ForeignKey("ASPNETUSER_ASPNETUSER_ID")]
        [InverseProperty("CLIENTE")]
        public virtual ASPNETUSER ASPNETUSER_ASPNETUSER { get; set; } = null!;
    }
}
