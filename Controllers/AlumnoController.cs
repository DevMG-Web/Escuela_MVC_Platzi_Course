using HolaMundoMVCPlatzi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolaMundoMVCPlatzi.Controllers
{
    public class AlumnoController:Controller
    {
        private readonly EscuelaContext context;

        public AlumnoController(EscuelaContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var alumno = from alum in context.Alumnos
                                 where alum.Id == id
                                 select alum;

                return View(alumno.SingleOrDefault());
            }
            else
            {
                return View("MultiAlumno", context.Alumnos);
            }
        }
        public IActionResult MultiAlumno()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View(context.Alumnos);
        }
    }
}
