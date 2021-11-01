using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HolaMundoMVCPlatzi.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Required]
        public override string Nombre { get => base.Nombre; set => base.Nombre = value; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        [Required]
        public string Direccion { get; set; }
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
    }
}