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
    
    public partial class TIPO
    {
        public TIPO()
        {
            this.USER_STORY = new HashSet<USER_STORY>();
        }
    
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    
        public virtual ICollection<USER_STORY> USER_STORY { get; set; }
    }
}
