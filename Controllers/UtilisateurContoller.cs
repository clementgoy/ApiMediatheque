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
}
