using AutoMapper;
using CL2TristanVela.Database;
using CL2TristanVela.Database.AlumnosContext;
using CL2TristanVela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CL2TristanVela.Controllers
{
    public class AlumnosController : Controller
    {
       private readonly IMapper _mapper;
       private readonly AlumnosContext _alumnoContext;

        public AlumnosController
            (
               AlumnosContext alumnoContext,
               IMapper mapper
            )
        {
            _alumnoContext = alumnoContext;
            _mapper = mapper;
        }

        public IActionResult Listado()
        {
            var alumnosEntity = _alumnoContext.Notas
                .Include(n => n.Alumno) 
                .ToList();

            var list = alumnosEntity.Select(a => new AlumnoViewModel
            {
                IdAlumno = a.Alumno.IdAlumno,
                NombreAlumno = a.Alumno.NombreAlumno,
                ApellidoAlumno = a.Alumno.ApellidoAlumno,
                DNI = a.Alumno.DNI,
                FechaNacimiento = a.Alumno.FechaNamiento,
                NombreCurso = a.NombreCurso,
                Nota = a.Nota
            }).ToList();

            return View(list);
        }



        public IActionResult Add()
        {
            AlumnoViewModel model = new AlumnoViewModel();
            return View(model);
        }

        public IActionResult AddSavedAction(AlumnoViewModel model, string nombreCurso, double nota)
        {
            AlumnosEntity alumnoEntity = new AlumnosEntity
            {
                NombreAlumno = model.NombreAlumno,
                ApellidoAlumno = model.ApellidoAlumno,
                DNI = model.DNI,
                FechaNamiento = model.FechaNacimiento
            };

            _alumnoContext.Alumnos.Add(alumnoEntity);
            _alumnoContext.SaveChanges();

            int idAlumno = alumnoEntity.IdAlumno;

            NotasEntity notaEntity = new NotasEntity
            {
                Alumno = alumnoEntity,
                NombreCurso = nombreCurso,
                Nota = ((byte)nota),
            };

            _alumnoContext.Notas.Add(notaEntity);
            _alumnoContext.SaveChanges();

            return RedirectToAction("Listado");
        }

        public IActionResult Edit(int id)
        {
            var alumnoEntity = _alumnoContext.Alumnos.SingleOrDefault(c => c.IdAlumno == id);

            if (alumnoEntity == null)
            {
                return RedirectToAction("Listado");
            }

            var alumnoViewModel = _mapper.Map<AlumnoViewModel>(alumnoEntity);

            return View(alumnoViewModel);
        }

        [HttpPost]
        public IActionResult EditSavedAction(AlumnoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var alumnoEntity = _mapper.Map<AlumnosEntity>(model);

                _alumnoContext.Entry(alumnoEntity).State = EntityState.Modified;

                var notasAsociadas = _alumnoContext.Notas.Where(n => n.Alumno.IdAlumno == alumnoEntity.IdAlumno).ToList();

                foreach (var notaEntity in notasAsociadas)
                {
                    notaEntity.NombreCurso = model.NombreCurso;
                    notaEntity.Nota = (byte)model.Nota;
                }

                _alumnoContext.SaveChanges();

                return RedirectToAction("Listado");
            }

            return View(model);
        }



        public IActionResult Delete(int id)
        {
            var notasAsociadas = _alumnoContext.Notas.Where(n => n.Alumno.IdAlumno == id).ToList();

            _alumnoContext.Notas.RemoveRange(notasAsociadas);
            _alumnoContext.SaveChanges();

            var findAlumno = _alumnoContext.Alumnos.SingleOrDefault(c => c.IdAlumno == id);
            _alumnoContext.Alumnos.Remove(findAlumno);
            _alumnoContext.SaveChanges();

            return RedirectToAction("Listado");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
