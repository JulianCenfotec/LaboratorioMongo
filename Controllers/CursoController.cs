using LaboratorioMongo.Modelos;
using LaboratorioMongo.Servicios; 
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaboratorioMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        private readonly CursoService _cursoService;

        public CursoController(CursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Curso>>> Get()
        {
            var cursos = await _cursoService.GetAsync();
            return Ok(cursos);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Curso>> Get(string Codigo)
        {
            var curso = await _cursoService.GetAsync(Codigo);

            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Curso newCurso)
        {
            await _cursoService.CreateAsync(newCurso);

            return CreatedAtAction(nameof(Get), new { id = newCurso.Codigo }, newCurso);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string Codigo, Curso updatedCurso)
        {
            var curso = await _cursoService.GetAsync(Codigo);

            if (curso == null)
            {
                return NotFound();
            }

            updatedCurso.Codigo = curso.Codigo;

            await _cursoService.UpdateAsync(Codigo, updatedCurso);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var curso = await _cursoService.GetAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            await _cursoService.RemoveAsync(id);

            return NoContent();
        }
    }
}
