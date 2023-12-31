﻿using LaboratorioMongo.Modelos;
using LaboratorioMongo.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioMongo.Controllers
{
    [ApiController]
    [Route("api/carreras")]
    public class CarreraController : ControllerBase
    {
        private readonly CarreraService _carreraService;

        public CarreraController(CarreraService carrreraService)
        {
            _carreraService = carrreraService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<Carrera>> Get() =>
            await _carreraService.GetAsync();

        [HttpGet]
        [Route("getbyid")]
        public async Task<ActionResult<Carrera>> Get(string id)
        {
            var carrera = await _carreraService.GetAsync(id);

            if (carrera is null)
            {
                return NotFound();
            }

            return carrera;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post(Carrera newCarrera)
        {
            await _carreraService.CreateAsync(newCarrera);

            return CreatedAtAction(nameof(Get), new { id = newCarrera.Id }, newCarrera);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(string id, Carrera updatedCarrera)
        {
            var carrera = await _carreraService.GetAsync(id);

            if (carrera is null)
            {
                return NotFound();
            }

            updatedCarrera.Id = carrera.Id;

            await _carreraService.UpdateAsync(id, updatedCarrera);

            return NoContent();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var carrera = await _carreraService.GetAsync(id);

            if (carrera is null)
            {
                return NotFound();
            }

            await _carreraService.RemoveAsync(id);

            return NoContent();
        }
    }
}
