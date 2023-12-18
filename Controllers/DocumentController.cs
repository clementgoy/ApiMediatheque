using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[ApiController]
[Route("api/document")]
public class DocumentController : ControllerBase
{
private readonly ApiMediathequeContext _context;
public DocumentController(ApiMediathequeContext context)
{
_context = context;
}


// GET: api/document
[HttpGet]
public async Task<ActionResult<IEnumerable<Document>>> GetDocuments()
{
// Get documents
var documents = _context.Documents;
return await documents.ToListAsync();
}

// GET: api/document/2
[HttpGet("{id}")]
public async Task<ActionResult<Document>> GetDocument(int id)
{
// Find a specific item
// SingleAsync() throws an exception if no item is found (which is possible, depending on id)
// SingleOrDefaultAsync() is a safer choice here
var document = await _context.Documents.SingleOrDefaultAsync(t => t.Id == id);


if (document == null)
return NotFound();

return document;
}

}
