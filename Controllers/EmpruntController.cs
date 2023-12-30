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
        _context.Emprunts.Add(emprunt);
        await _context.SaveChangesAsync();


        return CreatedAtAction(nameof(GetEmprunt), new { id = emprunt.Id }, emprunt);
    }

    // DELETE: api/emprunt
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmprunt(int id)
    {
        var emprunt = await _context.Emprunts.FindAsync(id);

        if (emprunt == null)
        {
            return NotFound();
        }

        _context.Emprunts.Remove(emprunt);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}
