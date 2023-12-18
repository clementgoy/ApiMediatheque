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

// POST: api/document
[HttpPost]
public async Task<ActionResult<Document>> PostDocument(Document document)
{
_context.Documents.Add(document);
await _context.SaveChangesAsync();


return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
}

// PUT: api/doucment/2
[HttpPut("{id}")]
public async Task<IActionResult> PutDocument(int id, Document document)
{
if (id != document.Id)
return BadRequest();


_context.Entry(document).State = EntityState.Modified;


try
{
await _context.SaveChangesAsync();
}
catch (DbUpdateConcurrencyException)
{
if (!_context.Documents.Any(m => m.Id == id))
return NotFound();
else
throw;
}

return NoContent();
}

// DELETE: api/document/2
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteDocument(int id)
{
var document = await _context.Documents.FindAsync(id);


if (document == null)
return NotFound();


_context.Documents.Remove(document);
await _context.SaveChangesAsync();

return NoContent();
}

}
