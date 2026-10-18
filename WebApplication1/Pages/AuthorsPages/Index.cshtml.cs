using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nume_Pren_Lab2.Models;

namespace WebApplication1.Pages.AuthorsPages;

public class IndexModel : PageModel
{
    private readonly WebApplication1Context _context;

    public IndexModel(WebApplication1Context context)
    {
        _context = context;
    }

    public IList<Authors> Authors { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Authors = await _context.Authors.ToListAsync();
    }
}
