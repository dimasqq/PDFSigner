using Microsoft.AspNetCore.Mvc;
using PDFSigner.DTOs;
using PDFSigner.Managers.Interfaces;

namespace PDFSigner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanysController : ControllerBase
    {
        private readonly ICompanyManager _manager;

        public CompanysController(ICompanyManager companyManager)
        {
            this._manager = companyManager;
        }

        [HttpGet("{id}")]
        //[Route("api/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var d = await _manager.GetAsync(id);

            return Ok(d);
        }

        [HttpPost]
        //[Route("api/{Company}")]
        public async Task<ActionResult<CompanyDTO>> Post([FromBody] CompanyPostDTO company)
        {
            var inserted = await _manager.InsertAsync(company);

            return CreatedAtAction(nameof(GetById), new { id = inserted.Id }, inserted);
        }

        [HttpPut("{id}")]
        //[Route("api/{id}")]
        public async Task<ActionResult<CompanyDTO>> Put(int id, [FromBody] CompanyPutDTO company)
        {
            var entity = await _manager.UpdateAsync(id, company);

            return Ok(entity);
        }
    }
}
