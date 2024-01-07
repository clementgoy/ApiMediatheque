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
        var documents = await _context.Documents.ToListAsync();
        foreach (Document doc in documents)
        {
            var emprunts = await _context.Emprunts.Where(d => d.EmprunteId == doc.Id).ToListAsync();
            var emprunteurs = new List<int>();
            foreach (var emprunt in emprunts)
            {
                emprunteurs.Add(emprunt.EmprunteurId);
            }
            doc.EmprunteurIds = emprunteurs;
            doc.Emprunt = emprunteurs.Count;
        }
        return documents;
    }

    // GET: api/document/2
    [HttpGet("{id}")]
    public async Task<ActionResult<Document>> GetDocument(int id)
    {
        var document = await _context.Documents.SingleOrDefaultAsync(t => t.Id == id);
        var emprunts = await _context.Emprunts.Where(d => d.Id == id).ToListAsync();
        var emprunteurs = new List<int>();

        if (document == null)
        {
            return NotFound();
        }
        foreach (Emprunt emprunt in emprunts)
        {
            emprunteurs.Add(emprunt.EmprunteurId);
        }
        document.EmprunteurIds = emprunteurs;

        return document;
    }

    // POST: api/document
    [HttpPost]
    public async Task<ActionResult<Document>> PostDocument(Document document)
    {
        if (document.Stock <= 0)
        {
            return BadRequest("Le stock doit être au moins 1.");
        }

        _context.Documents.Add(document);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
    }

    // PUT: api/doucment/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDocument(int id, Document document)
    {
        if (id != document.Id)
        {
            return BadRequest();
        }

        var empruntsEnCours = await _context.Emprunts.CountAsync(e => e.EmprunteId == id);

        // Vérifie si la nouvelle valeur du stock est inférieure au nombre d'emprunts en cours
        if (document.Stock < empruntsEnCours)
        {
            return BadRequest($"Le stock ne peut pas être inférieur au nombre d'emprunts en cours.");
        }

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

