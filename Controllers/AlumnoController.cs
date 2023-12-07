using LaboratorioMongo.Fabrica;
using LaboratorioMongo.Modelos;
using LaboratorioMongo.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioMongo.Controllers
{
    [ApiController]
    [Route("api/alumnos")]
    public class AlumnoController : Controller
    {
        private readonly AlumnoService _alumnoService;

        public AlumnoController(AlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<Alumno>> Get() {
           var alumnos = await _alumnoService.GetAsync();
            return alumnos;
        }


        [HttpGet]
        [Route("getbyid")]
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
        [Route("create")]
        public async Task<IActionResult> Post(Alumno newAlumno)
        {
            await _alumnoService.CreateAsync(newAlumno);

            return CreatedAtAction(nameof(Get), new { id = newAlumno.Id }, newAlumno);
        }

        [HttpPut]
        [Route("update")]
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

        [HttpDelete]
        [Route("delete")]
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
