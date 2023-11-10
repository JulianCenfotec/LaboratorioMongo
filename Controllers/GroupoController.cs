using LaboratorioMongo.Modelos;
using LaboratorioMongo.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioMongo.Controllers
{
    [ApiController]
    [Route("api/grupos")]
    public class GroupoController : Controller
    {

        private readonly GrupoService _grupoService;

        public GroupoController(GrupoService grupoService) 
        {
            _grupoService = grupoService;
        }
        [HttpGet]
        public async Task<List<Grupo>> Get() =>
            await _grupoService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Grupo>> Get(string id)
        {
            var grupo = await _grupoService.GetAsync(id);

            if (grupo is null)
            {
                return NotFound();
            }

            return grupo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Grupo newGrupo)
        {
            await _grupoService.CreateAsync(newGrupo);

            return CreatedAtAction(nameof(Get), new { id = newGrupo.Id }, newGrupo);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Grupo updatedGrupo)
        {
            var grupo = await _grupoService.GetAsync(id);

            if (grupo is null)
            {
                return NotFound();
            }

            updatedGrupo.Id = grupo.Id;

            await _grupoService.UpdateAsync(id, updatedGrupo);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var grupo = await _grupoService.GetAsync(id);

            if (grupo is null)
            {
                return NotFound();
            }

            await _grupoService.RemoveAsync(id);

            return NoContent();
        }
    }
}
