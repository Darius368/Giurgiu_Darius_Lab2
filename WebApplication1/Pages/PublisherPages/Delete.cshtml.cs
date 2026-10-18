using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nume_Pren_Lab2.Models;

namespace WebApplication1.Pages.PublisherPages;

public class DeleteModel : PageModel
{
    private readonly WebApplication1Context _context;

    public DeleteModel(WebApplication1Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Publisher Publisher { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
        if (publisher is null)
        {
            return NotFound();
        }
        else
        {
            Publisher = publisher;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var publisher = await _context.Publisher.FindAsync(id);
        if (publisher != null)
        {
            Publisher = publisher;
            _context.Publisher.Remove(Publisher);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
