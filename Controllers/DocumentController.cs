using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// Importez les espaces de noms nécessaires pour les DTO
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            .Include(d => d.Livre)
            .Include(d => d.Magazine)
            .Include(d => d.Media)
            .ToListAsync();

        var documentDTOs = documents.Select(d => new DocumentDTO
        {
            Id = d.Id,
            Titre = d.Titre,
            Auteur = d.Auteur,
            Stock = d.Stock,
            Emprunt = _context.Emprunts.Count(e => e.EmprunteId == d.Id),
            Type = d.Type,
            Genre = d.Livre?.Genre,
            Support = d.Media?.Support,
            Publication = d.Magazine?.Publication
        }).ToList();

        return documentDTOs;
    }

    // GET: api/document/2
    [HttpGet("{id}")]
    public async Task<ActionResult<DocumentDTO>> GetDocument(int id)
    {
        var document = await _context.Documents
            .Include(d => d.Livre)
            .Include(d => d.Magazine)
            .Include(d => d.Media)
            .SingleOrDefaultAsync(t => t.Id == id);

        if (document == null)
        {
            return NotFound();
        }

        var documentDTO = new DocumentDTO
        {
            Id = document.Id,
            Titre = document.Titre,
            Auteur = document.Auteur,
            Stock = document.Stock,
            Emprunt = _context.Emprunts.Count(e => e.EmprunteId == document.Id),
            Type = document.Type,
            Genre = document.Livre?.Genre,
            Support = document.Media?.Support,
            Publication = document.Magazine?.Publication
        };

        return documentDTO;
    }

    // POST: api/document
    [HttpPost]
    public async Task<ActionResult<DocumentDTO>> PostDocument(DocumentDTO documentDTO)
    {
        Document document;

        switch (documentDTO.Type)
        {
            case "Livre":
                document = new Livre(documentDTO.ToLivreDTO(), _context);
                break;

            case "Magazine":
                document = new Magazine(documentDTO.ToMagazineDTO(), _context);
                break;

            case "Media":
                document = new Media(documentDTO.ToMediaDTO(), _context);
                break;

            default:
                return BadRequest("Type de document non pris en charge.");
        }

        _context.Documents.Add(document);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, documentDTO);
    }

    // PUT: api/document/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDocument(int id, DocumentDTO documentDTO)
    {
        var document = await _context.Documents
            .Include(d => d.Livre)
            .Include(d => d.Magazine)
            .Include(d => d.Media)
            .SingleOrDefaultAsync(d => d.Id == id);

        if (document == null)
        {
            return NotFound();
        }

        document.Titre = documentDTO.Titre;
        document.Auteur = documentDTO.Auteur;
        document.Stock = documentDTO.Stock;

        switch (documentDTO.Type)
        {
            case "Livre":
                document.Livre.Genre = documentDTO.Genre;
                break;

            case "Magazine":
                document.Magazine.Publication = documentDTO.Publication;
                break;

            case "Media":
                document.Media.Support = documentDTO.Support;
                break;

            default:
                return BadRequest("Type de document non pris en charge.");
        }

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

