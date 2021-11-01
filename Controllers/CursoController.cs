using HolaMundoMVCPlatzi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolaMundoMVCPlatzi.Controllers
{
    public class CursoController:Controller
    {
        private readonly EscuelaContext context;

        public CursoController(EscuelaContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var curso = context.Cursos
                    .FirstOrDefault(c => c.Id == id);
                               
                return View(curso);
            }
            else
            {
                return View("MultiCurso", context.Cursos);
            }
        }

        public IActionResult MultiCurso()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View(context.Cursos);
        }

        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind(include: "Nombre, Dirección, Jornada")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                var escuela = context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;

                context.Add(curso);
                context.SaveChanges();
                ViewBag.MensajeExtra = "Curso Creado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }

        [HttpGet]
        [Route("Curso/Edit/{CursoId}")]
        public IActionResult Edit(string CursoId)
        {
            if (!string.IsNullOrEmpty(CursoId))
            {
                var model = context.Cursos.FirstOrDefault(m => m.Id == CursoId);

                if(model is null)
                {
                    return NotFound();
                }

                return View(model);
            }

            return View("MultiCurso", context.Cursos);
        }

        [HttpPost]
        public IActionResult Edit([Bind(include: "Id, Nombre, Direccion, Jornada")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                var escuela = context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;

                context.Entry(curso).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                ViewBag.MensajeExtra = "Curso Actualizado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }

    }
}
