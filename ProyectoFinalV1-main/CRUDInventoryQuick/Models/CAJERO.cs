using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("CAJEROS")]
    public partial class CAJERO
    {
        /// <summary>
        /// Identificador unico de usuario cajero
        /// </summary>
        [Key]
        [Column(TypeName = "numeric(28, 0)")]
        public decimal ASPNETUSER_ASPNETUSER_ID { get; set; }

        [ForeignKey("ASPNETUSER_ASPNETUSER_ID")]
        [InverseProperty("CAJERO")]
        public virtual ASPNETUSER ASPNETUSER_ASPNETUSER { get; set; } = null!;
    }
}
