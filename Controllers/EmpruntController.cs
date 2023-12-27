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
        // Get utilisateurs and related lists
        var emprunts = _context.Em;
        return await utilisateurs.ToListAsync();
    }

// POST: api/utilisateur
    [HttpPost]
    public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
    {
        _context.Utilisateurs.Add(utilisateur);
        await _context.SaveChangesAsync();


        return CreatedAtAction(nameof(GetUtilisateur), new { id = utilisateur.Id }, utilisateur);
    }

    // DELETE: api/utilisateur/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUtilisateur(int id)
    {
        var utilisateur = await _context.Utilisateurs.FindAsync(id);


        if (utilisateur == null)
            return NotFound();


        _context.Utilisateurs.Remove(utilisateur);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
}
