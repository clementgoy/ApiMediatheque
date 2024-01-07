using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/emprunt")]
public class EmpruntController : ControllerBase
{
    private readonly ApiMediathequeContext _context;
    public EmpruntController(ApiMediathequeContext context)
    {
        _context = context;
    }

    // GET : api/emprunt
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Emprunt>>> GetEmprunts()
    {
        var emprunts = _context.Emprunts;
        return await emprunts.ToListAsync();
    }

    // GET : api/emprunt/2
    [HttpGet("{id}")]
    public async Task<ActionResult<Emprunt>> GetEmprunt(int id)
    {
        var emprunt = await _context.Emprunts.SingleOrDefaultAsync(t => t.Id == id);

        if (emprunt == null)
            return NotFound();

        return emprunt;
    }

    // POST: api/emprunt
    [HttpPost]
    public async Task<ActionResult<Emprunt>> PostEmprunt(Emprunt emprunt)
    {
        // Vérifie si l'emprunteur existe
        var emprunteur = await _context.Utilisateurs.FindAsync(emprunt.EmprunteurId);
        if (emprunteur == null)
        {
            return NotFound($"L'utilisateur avec l'ID {emprunt.EmprunteurId} n'existe pas.");
        }

        // Vérifie si le document existe
        var document = await _context.Documents.FindAsync(emprunt.EmprunteId);
        if (document == null)
        {
            return NotFound($"Le document avec l'ID {emprunt.EmprunteId} n'existe pas.");
        }

        // Vérifie si l'ID de l'emprunt existe déjà
        if (await _context.Emprunts.AnyAsync(e => e.Id == emprunt.Id))
        {
            return BadRequest($"L'ID {emprunt.Id} de l'emprunt existe déjà. Choisissez un autre ID.");
        }

        // Vérifie si l'utilisateur a déjà emprunté le document
        var hasAlreadyBorrowed = await _context.Emprunts.AnyAsync(e => e.EmprunteurId == emprunt.EmprunteurId && e.EmprunteId == emprunt.EmprunteId);
        if (hasAlreadyBorrowed)
        {
            return BadRequest($"L'utilisateur avec l'ID {emprunt.EmprunteurId} a déjà emprunté le document avec l'ID {emprunt.EmprunteId}.");
        }

        // Vérifie si le stock est suffisant
        var nbEmpruntsEnCours = await _context.Emprunts.CountAsync(e => e.EmprunteId == emprunt.EmprunteId);
        if (nbEmpruntsEnCours >= document.Stock)
        {
            return BadRequest($"Stock insuffisant. Tous les exemplaires du document avec l'ID {emprunt.EmprunteId} sont déjà empruntés.");
        }

        // Vérifie si l'utilisateur est en retard pour rendre un document
        var isUserLate = await _context.Emprunts.AnyAsync(e => e.EmprunteurId == emprunt.EmprunteurId && e.DateEmprunt.AddDays(15) < DateTime.Now);
        if (isUserLate)
        {
            return BadRequest($"L'utilisateur avec l'ID {emprunt.EmprunteurId} est en retard pour rendre un document. Il ne peut pas emprunter de nouveau.");
        }

        // Ajoute l'emprunt à la base de données
        emprunt.DateEmprunt = DateTime.Now; // Ajoute la date de l'emprunt à la base de données
        _context.Emprunts.Add(emprunt);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEmprunt), new { id = emprunt.Id }, emprunt);
    }



    // DELETE: api/emprunt
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmprunt(int id)
    {
        var emprunt = await _context.Emprunts.FindAsync(id);
        var document = await _context.Documents.FindAsync(emprunt.EmprunteId);


        if (emprunt == null)
        {
            return NotFound();
        }

        _context.Emprunts.Remove(emprunt);

        await _context.SaveChangesAsync();

        return NoContent();
    }


}
