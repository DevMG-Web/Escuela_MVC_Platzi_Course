using HolaMundoMVCPlatzi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolaMundoMVCPlatzi.Controllers
{
    public class EscuelaController : Controller
    {
        private readonly EscuelaContext context;

        public EscuelaController(EscuelaContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var escuela = context.Escuelas.FirstOrDefault();
            return View(escuela);
        }
    }
}
