//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScrumAdmin.Models
{
    using System;
    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    
    public partial class USUARIO
    {
        public USUARIO()
        {
            this.EQUIPO = new HashSet<EQUIPO>();
        }
    
        public int ID { get; set; }
        
        [Required]
        [Display(Name = "Nombre")]
        public string AP1 { get; set; }

        [Display(Name = "Apellido")]
        public string AP2 { get; set; }

        [Required]
        [Display(Name = "Correo")]
        public string EMAIL { get; set; }

        [Display(Name = "Celular")]
        public string CELULAR { get; set; }

        [Required]
        [Display(Name = "NickName")]
        public string NICK { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string CONTRASENNIA { get; set; }
    
        public virtual ICollection<EQUIPO> EQUIPO { get; set; }
    }
}
