using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumAdmin.Models
{
    public class SINGLETON
    {
        
        private static SINGLETON instancia = null;

        public int idProyecto { get; set; }
        
        public int idUsuario { get; set; }

        public int idRol { get; set; }

        private SINGLETON() { }

        public static SINGLETON Create()
        {
            if (instancia == null)
                instancia = new SINGLETON();
            return instancia;
        }

    }
}