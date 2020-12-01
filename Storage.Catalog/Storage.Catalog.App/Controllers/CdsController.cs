using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdsController : ControllerBase
    {
        private readonly ICdRepository CdRepository;

        public CdsController(ICdRepository cdRepository)
        {
            CdRepository = cdRepository;
        }

        [HttpGet("{id}/image")]
        public async Task<IActionResult> GetImage(int id)
        {
            var cd = await CdRepository.GetByIdAsync(id);
            return File(cd.Image, "image/jpeg");
        }

        [HttpGet]
        public async Task<IEnumerable<Cd>> Get()
        {
            return await CdRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await CdRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var cd = await GetCdFromForm();
            cd.Id = await CdRepository.SaveAsync(cd);
            return Created($"/cds/{cd.Id}", cd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            if (CdRepository.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await CdRepository.SaveAsync(await GetCdFromForm());

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (CdRepository.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await CdRepository.DeleteAsync(id);

            return Ok();
        }

        private async Task<Cd> GetCdFromForm()
        {
            var cd = JsonConvert.DeserializeObject<Cd>(Request.Form["productData"]);

            if (!Request.Form.Files.Any())
            {
                return cd;
            }

            var formFileStream = Request.Form.Files.First().OpenReadStream();
            var buffer = new byte[formFileStream.Length];

            await formFileStream.ReadAsync(buffer, 0, buffer.Length);

            cd.Image = buffer;

            return cd;
        }
    }
}
