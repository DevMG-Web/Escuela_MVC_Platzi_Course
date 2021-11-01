using HolaMundoMVCPlatzi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolaMundoMVCPlatzi.Controllers
{
    public class AsignaturaController : Controller
    {
        private readonly EscuelaContext context;
        public AsignaturaController(EscuelaContext context)
        {
            this.context = context;
        }

        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{AsignaturaId}")]
        public IActionResult Index(string AsignaturaId)
        {
            if (!string.IsNullOrWhiteSpace(AsignaturaId))
            {
                var asignatura = from asig in context.Asignaturas
                                 where asig.Id == AsignaturaId
                                 select asig;

                return View(asignatura.SingleOrDefault());
            }
            else
            {
                return View("MultiAsignatura", context.Asignaturas);
            }
            
        }

        public IActionResult MultiAsignatura()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;
            
            return View("MultiAsignatura", context.Asignaturas);
        }
    }
}
