using System;
using System.Collections.Generic;

#nullable disable

namespace OFERTALABORAL_WEB_API.Models
{
    public partial class OfertaLaboral
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Empresa { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Lugar { get; set; }
    }
}
