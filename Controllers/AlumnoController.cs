using LaboratorioMongo.Modelos;
using LaboratorioMongo.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioMongo.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly AlumnoService _alumnoService;

        public AlumnoController(AlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        [HttpGet]
        public async Task<List<Alumno>> Get() =>
            await _alumnoService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Alumno>> Get(string id)
        {
            var user = await _alumnoService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Alumno newAlumno)
        {
            await _alumnoService.CreateAsync(newAlumno);

            return CreatedAtAction(nameof(Get), new { id = newAlumno.Id }, newAlumno);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Alumno updatedAlumno)
        {
            var user = await _alumnoService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            updatedAlumno.Id = user.Id;

            await _alumnoService.UpdateAsync(id, updatedAlumno);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _alumnoService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            await _alumnoService.RemoveAsync(id);

            return NoContent();
        }
    }
}
