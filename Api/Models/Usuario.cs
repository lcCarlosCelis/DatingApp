using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Usuario
    {
        [Key]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime Creado { get; set; }
        public DateTime UltimoLog { get; set; }
        public ICollection<Foto> Fotos { get; set; }
    }
}
