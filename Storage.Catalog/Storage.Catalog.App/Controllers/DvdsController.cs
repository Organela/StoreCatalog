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
    public class DvdsController : ControllerBase
    {
        private readonly IDvdRepository DvdRepository;

        public DvdsController(IDvdRepository dvdRepository)
        {
            DvdRepository = dvdRepository;
        }

        [HttpGet("{id}/image")]
        public async Task<IActionResult> GetImage(int id)
        {
            var dvd = await DvdRepository.GetByIdAsync(id);
            return File(dvd.Image, "image/jpeg");
        }

        // GET: api/Dvds
        [HttpGet]
        public async Task<IEnumerable<Dvd>> Get()
        {
            return await DvdRepository.GetAllAsync();
        }

        // GET: api/Dvds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await DvdRepository.GetByIdAsync(id));
        }

        // POST: api/Dvds
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok(await DvdRepository.SaveAsync(await GetDvdFromForm()));
        }

        private async Task<Dvd> GetDvdFromForm()
        {
            var dvd = JsonConvert.DeserializeObject<Dvd>(Request.Form["productData"]);

            if (!Request.Form.Files.Any())
            {
                return dvd;
            }

            var formFileStream = Request.Form.Files.First().OpenReadStream();
            var buffer = new byte[formFileStream.Length];

            await formFileStream.ReadAsync(buffer, 0, buffer.Length);

            dvd.Image = buffer;

            return dvd;
        }

        // PUT: api/Dvds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put()
        {
            return Ok(await DvdRepository.SaveAsync(await GetDvdFromForm()));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await DvdRepository.DeleteAsync(id));
        }
    }
}
