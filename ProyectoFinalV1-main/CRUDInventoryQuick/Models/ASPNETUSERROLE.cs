using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("ASPNETUSERROLE")]
    public partial class ASPNETUSERROLE
    {
        public ASPNETUSERROLE()
        {
            ASPNETUSER_ASPNETUSERs = new HashSet<ASPNETUSER>();
        }

        /// <summary>
        /// Identificador unico de Rol
        /// </summary>
        [Key]
        public int AspNetRoleId { get; set; }
        /// <summary>
        /// Indica el nombre del rol correspondiente
        /// </summary>
        [StringLength(64)]
        public string Nombre { get; set; } = null!;

        [ForeignKey("ASPNETUSERROLE_AspNetRoleId")]
        [InverseProperty("ASPNETUSERROLE_AspNetRoles")]
        public virtual ICollection<ASPNETUSER> ASPNETUSER_ASPNETUSERs { get; set; }
    }
}
