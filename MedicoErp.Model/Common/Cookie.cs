﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Common
{
    public class Cookie
    {
        public string Respuesta { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string CodSexo { get; set; }
        public int IdCentro { get; set; }
        public string NombreCentro { get; set; }
        public string Avatar { get; set; }
        public string Menu { get; set; }
    }
}
