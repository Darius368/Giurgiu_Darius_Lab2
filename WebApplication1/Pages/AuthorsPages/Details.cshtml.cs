using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nume_Pren_Lab2.Models;

namespace WebApplication1.Pages.AuthorsPages;

public class DetailsModel : PageModel
{
    private readonly WebApplication1Context _context;
    public DetailsModel(WebApplication1Context context)
    {
        _context = context;
    }

    public Authors Authors { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var authors = await _context.Authors.FirstOrDefaultAsync(m => m.ID == id);
        if (authors is null)
        {
            return NotFound();
        }
        else
        {
            Authors = authors;
        }

        return Page();
    }
}
