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

        // GET: api/Cds
        [HttpGet]
        public async Task<IList<Cd>> Get()
        {
            return (await CdRepository.GetAllAsync()).ToList();
        }

        // GET: api/Cds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await CdRepository.GetByIdAsync(id));
        }

        // POST: api/Cds
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok(await CdRepository.SaveAsync(await GetCdFromForm()));
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

        // PUT: api/Cds/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
