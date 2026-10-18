using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nume_Pren_Lab2.Models;

namespace WebApplication1.Pages.PublisherPages;

public class CreateModel : PageModel
{
    private readonly WebApplication1Context _context;

    public CreateModel(WebApplication1Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Publisher Publisher { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {

        ModelState.Remove("Publisher.Books");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Publisher.Add(Publisher);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
