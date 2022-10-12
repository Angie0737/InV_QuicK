using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Models
{
    [Table("ASPNETUSER")]
    public partial class ASPNETUSER
    {
        public ASPNETUSER()
        {
            ASPNETUSERCLAIMs = new HashSet<ASPNETUSERCLAIM>();
            ASPNETUSERLOGINs = new HashSet<ASPNETUSERLOGIN>();
            ASPNETUSERROLE_AspNetRoles = new HashSet<ASPNETUSERROLE>();
        }

        /// <summary>
        /// Identificador unico de usuario
        /// </summary>
        [Key]
        [Column(TypeName = "numeric(28, 0)")]
        public decimal ASPNETUSER_ID { get; set; }
        /// <summary>
        /// Indica el nombre del usuario
        /// </summary>
        public int NombreNetUserId { get; set; }
        /// <summary>
        /// Indica nombre de la persona
        /// </summary>
        [StringLength(64)]
        public string Nombres { get; set; } = null!;
        /// <summary>
        /// Indica apellidos de la persona
        /// </summary>
        [StringLength(64)]
        public string Apellidos { get; set; } = null!;
        /// <summary>
        /// Indica fecha de nacimiento de usuario
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        /// <summary>
        /// Indica dirección de usuario
        /// </summary>
        [StringLength(64)]
        public string Direccion { get; set; } = null!;
        /// <summary>
        /// Indica telefono de usuario
        /// </summary>
        [StringLength(64)]
        public string Telefono { get; set; } = null!;
        /// <summary>
        /// Indica el correo del usuario
        /// </summary>
        [StringLength(64)]
        public string Correo { get; set; } = null!;
        /// <summary>
        /// Indica si el correo ha sido confirmado
        /// </summary>
        public bool CorreoConfirmado { get; set; }
        /// <summary>
        /// Indica la contraseña de usuario
        /// </summary>
        [StringLength(64)]
        public string Contrasena { get; set; } = null!;
        /// <summary>
        /// Indica el sello de seguridad del usuario
        /// </summary>
        [StringLength(64)]
        public string SelloDeSeguridad { get; set; } = null!;
        /// <summary>
        /// Indica el reclamo de telefono usuario
        /// </summary>
        [StringLength(64)]
        public string ReclamarTelefono { get; set; } = null!;
        /// <summary>
        /// Indica factores disponibles
        /// </summary>
        [StringLength(64)]
        public string DosFactoresDisponibles { get; set; } = null!;
        /// <summary>
        /// Indica fecha cierre usuario
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime FechaCierre { get; set; }
        /// <summary>
        /// Indica fecha abierta usuario
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime FechaAbierta { get; set; }
        /// <summary>
        /// Indica si el aceeso ha sido denegado
        /// </summary>
        [StringLength(64)]
        public string AccesoDenegado { get; set; } = null!;

        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual ADMINISTRADOR ADMINISTRADOR { get; set; } = null!;
        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual CAJERO CAJERO { get; set; } = null!;
        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual CLIENTE CLIENTE { get; set; } = null!;
        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual EMPLEADO EMPLEADO { get; set; } = null!;
        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual ICollection<ASPNETUSERCLAIM> ASPNETUSERCLAIMs { get; set; }
        [InverseProperty("ASPNETUSER_ASPNETUSER")]
        public virtual ICollection<ASPNETUSERLOGIN> ASPNETUSERLOGINs { get; set; }

        [ForeignKey("ASPNETUSER_ASPNETUSER_ID")]
        [InverseProperty("ASPNETUSER_ASPNETUSERs")]
        public virtual ICollection<ASPNETUSERROLE> ASPNETUSERROLE_AspNetRoles { get; set; }
    }
}
