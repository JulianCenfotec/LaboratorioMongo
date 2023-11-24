using LaboratorioMongo.Fabrica;
using LaboratorioMongo.Modelos;
using LaboratorioMongo.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioMongo.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IPersonaService<Teacher> _teacherService;

        public TeacherController(IPersonaService<Teacher> teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<List<Teacher>> Get() =>
            await _teacherService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Teacher>> Get(string id)
        {
            var user = await _teacherService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Teacher newTeacher)
        {
            await _teacherService.CreateAsync(newTeacher);

            return CreatedAtAction(nameof(Get), new { id = newTeacher.Id }, newTeacher);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Teacher updatedTeacher)
        {
            var user = await _teacherService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            updatedTeacher.Id = user.Id;

            await _teacherService.UpdateAsync(id, updatedTeacher);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _teacherService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            await _teacherService.RemoveAsync(id);

            return NoContent();
        }
    }
}