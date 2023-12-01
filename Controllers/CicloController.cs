using Microsoft.AspNetCore.Mvc;
using LaboratorioMongo.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaboratorioMongo.Servicios;

namespace LaboratorioMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CicloController : ControllerBase
    {
        private readonly CicloService _cicloService;

        public CicloController(CicloService cicloService)
        {
            _cicloService = cicloService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Facturacion>>> Get()
        {
            var ciclos = await _cicloService.GetAsync();
            return Ok(ciclos);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Facturacion>> Get(string id)
        {
            var ciclo = await _cicloService.GetAsync(id);

            if (ciclo == null)
            {
                return NotFound();
            }

            return Ok(ciclo);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Facturacion newCiclo)
        {
            await _cicloService.CreateAsync(newCiclo);

            return CreatedAtAction(nameof(Get), new { id = newCiclo.Id }, newCiclo);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Facturacion updatedCiclo)
        {
            var ciclo = await _cicloService.GetAsync(id);

            if (ciclo == null)
            {
                return NotFound();
            }

            updatedCiclo.Id = ciclo.Id;

            await _cicloService.UpdateAsync(id, updatedCiclo);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var ciclo = await _cicloService.GetAsync(id);

            if (ciclo == null)
            {
                return NotFound();
            }

            await _cicloService.RemoveAsync(id);

            return NoContent();
        }
    }
}
