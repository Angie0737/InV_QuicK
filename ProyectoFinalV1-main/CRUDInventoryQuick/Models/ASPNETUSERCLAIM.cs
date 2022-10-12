using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("ASPNETUSERCLAIM")]
    public partial class ASPNETUSERCLAIM
    {
        /// <summary>
        /// Identificador unico de llave
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Indica el tipo de llave
        /// </summary>
        [StringLength(64)]
        public string ClaimType { get; set; } = null!;
        /// <summary>
        /// Indica el valor de la llave
        /// </summary>
        [StringLength(64)]
        public string ClaimValue { get; set; } = null!;
        /// <summary>
        /// Identificador unico del usuario
        /// </summary>
        public int AspNetUserId { get; set; }
        /// <summary>
        /// Identificador unico de usuario
        /// </summary>
        [Column(TypeName = "numeric(28, 0)")]
        public decimal ASPNETUSER_ASPNETUSER_ID { get; set; }

        [ForeignKey("ASPNETUSER_ASPNETUSER_ID")]
        [InverseProperty("ASPNETUSERCLAIMs")]
        public virtual ASPNETUSER ASPNETUSER_ASPNETUSER { get; set; } = null!;
    }
}
