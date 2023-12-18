using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore;

[ApiController]
[Route("api/utilisateur")]
public class UtilisateurController : ControllerBase
{
    private readonly MediathequeContext _context;
    public UtilisateurController(MediathequeContext context)
    {
        _context = context;
    }

    // GET : api/utilisateur
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all utilisateurs")
    ]
    [SwaggerResponse(StatusCodes.Status2000k, "Utilisateurs found", typeof(IEnumerable<Utilisateur>))]
    public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
    {
        // Get utilisateurs and related lists
        var utilisateurs = _context.Utilisateurs.Include(t => t.List);
        return await utilisateurs.ToListAsync();
    }

    // GET : api/utilisateur/2
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get an utilisateur by id"
    )]
    [SwaggerResponse(StatusCodes.Status2000k, "Utilisateur found", typeof(Utilisateur))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Utilisateur not found")]
    public async Task<ActionResult<Utilisateur>> GetUtilisateur([SwaggerParametre("The utilisateur id", Required = true)] int id)
    {
        var utilisateur = await _context.Utilisateurs.Include(t => t.List).SingleOrDefaultAsync(t => t.Id == id);

        if (utilisateur == null)
            return NotFound();

        return utilisateur;
    }
}
