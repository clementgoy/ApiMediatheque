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

    

}
