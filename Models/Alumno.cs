using System;
using System.Collections.Generic;

namespace HolaMundoMVCPlatzi.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; } 
    }
}