using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("ASPNETUSERLOGIN")]
    public partial class ASPNETUSERLOGIN
    {
        /// <summary>
        /// Identificador unico de ingresar
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Indica ingreso
        /// </summary>
        [StringLength(64)]
        public string LoginProvider { get; set; } = null!;
        /// <summary>
        /// Indica llave
        /// </summary>
        [StringLength(64)]
        public string ProviderKey { get; set; } = null!;
        /// <summary>
        /// Identificador unico de usuario
        /// </summary>
        [Column(TypeName = "numeric(28, 0)")]
        public decimal ASPNETUSER_ASPNETUSER_ID { get; set; }

        [ForeignKey("ASPNETUSER_ASPNETUSER_ID")]
        [InverseProperty("ASPNETUSERLOGINs")]
        public virtual ASPNETUSER ASPNETUSER_ASPNETUSER { get; set; } = null!;
    }
}
