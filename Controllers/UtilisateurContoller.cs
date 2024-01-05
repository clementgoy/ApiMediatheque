using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/utilisateur")]
public class UtilisateurController : ControllerBase
{
    private readonly ApiMediathequeContext _context;
    public UtilisateurController(ApiMediathequeContext context)
    {
        _context = context;
    }

    // GET : api/utilisateur
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
    {
        // Get utilisateurs and related lists
        var utilisateurs = _context.Utilisateurs;
        return await utilisateurs.ToListAsync();
    }

    // GET : api/utilisateur/2
    [HttpGet("{id}")]
    public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
    {
        var utilisateur = await _context.Utilisateurs.SingleOrDefaultAsync(t => t.Id == id);


        if (utilisateur == null)
            return NotFound();

        return utilisateur;
    }

    // POST: api/utilisateur
    [HttpPost]
    public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
    {
        _context.Utilisateurs.Add(utilisateur);
        await _context.SaveChangesAsync();


        return CreatedAtAction(nameof(GetUtilisateur), new { id = utilisateur.Id }, utilisateur);
    }

    // PUT: api/utilisateur/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
    {
        if (id != utilisateur.Id)
            return BadRequest();


        _context.Entry(utilisateur).State = EntityState.Modified;


        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Utilisateurs.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/utilisateur/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUtilisateur(int id)
    {
        var utilisateur = await _context.Utilisateurs.FindAsync(id);

        if (utilisateur == null)
            return NotFound();

        var empruntsASupprimer = _context.Emprunts.Where(e => e.EmprunteurId == id);


        if (empruntsASupprimer == null)
        {
            _context.Utilisateurs.Remove(utilisateur);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        _context.Utilisateurs.Remove(utilisateur);
        _context.Emprunts.RemoveRange(empruntsASupprimer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
