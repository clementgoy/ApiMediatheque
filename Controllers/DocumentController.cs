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
    public async Task<ActionResult<IEnumerable<DocumentDTO>>> GetDocuments()
    {
        var documents = await _context.Documents
            .Select(d => new DocumentDTO(d, _context))
            .ToListAsync();

        return documents;
    }


    // GET: api/document/2
    [HttpGet("{id}")]
    public async Task<ActionResult<DocumentDTO>> GetDocument(int id)
    {
        var document = await _context.Documents
            .Where(d => d.Id == id)
            .Select(d => new DocumentDTO(d, _context))
            .SingleOrDefaultAsync();

        if (document == null)
        {
            return NotFound();
        }

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
        {
            return NotFound();
        }

        var empruntsASupprimer = _context.Emprunts.Where(e => e.EmprunteId == id);

        if (empruntsASupprimer == null)
        {
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        _context.Documents.Remove(document);
        _context.Emprunts.RemoveRange(empruntsASupprimer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
