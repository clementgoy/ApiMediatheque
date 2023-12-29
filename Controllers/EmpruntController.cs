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

    // DELETE: api/utilisateur/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUtilisateur(int id)
    {
        var utilisateur = await _context.Utilisateurs.FindAsync(id);

        if (utilisateur == null)
            return NotFound();

        var empruntsASupprimer = _context.Emprunts.Where(e => e.Emprunteur.Id == id);

        _context.Utilisateurs.Remove(utilisateur);
        _context.Emprunts.RemoveRange(empruntsASupprimer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
