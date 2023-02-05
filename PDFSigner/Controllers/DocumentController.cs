using Microsoft.AspNetCore.Mvc;
using PDFSigner.DTOs;
using PDFSigner.Managers.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDFSigner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IDocumentManager _manager;

        public DocumentController(IDocumentManager documentManager)
        {
            this._manager = documentManager;
        }

        // GET api/<DocumentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var d = await _manager.GetAsync(id);
            return Ok(d);
        }

        // POST api/<DocumentController>
        [HttpPost]
        public async Task<ActionResult<DocumentDTO>> Post(DocumentPostDTO document)
        {
            /*using (var ms = new MemoryStream())
            {
                documentFile.RecievedFile.CopyTo(ms);
                document.PdfFile = ms.ToArray();
            }*/

            var inserted = await _manager.InsertAsync(document);
            return CreatedAtAction(nameof(GetById), new { id = inserted.Id }, inserted);
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DocumentDTO>> Put(int id, [FromBody] DocumentPutDTO document)
        {
            var entity = await _manager.UpdateAsync(id, document);

            return Ok(entity);
        }

        [HttpPut("/Sign/{id}")]
        public async Task<ActionResult<DocumentDTO>> Sign(int id)
        {
            var entity = await _manager.SignAsync(id);

            return Ok(entity);
        }

        [HttpPost("/AddSigner")]
        public async Task<ActionResult<CompanyDocumentDTO>> AddSigner(int companyId, int documentId)
        {
            var entity = await _manager.AddSigner(companyId, documentId);

            return Ok(entity);
        }

        [HttpGet("/ViewDocument")]
        public async Task<ActionResult<CompanyDocumentDTO>> ViewDocument(int companyId, int documentId)
        {
            var entity = await _manager.ViewDocument(companyId, documentId);

            return Ok(entity);
        }


        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocumentDTO>> Delete(int id)
        {
            await _manager.DeleteAsync(id);
            return Ok();
        }
    }
}
