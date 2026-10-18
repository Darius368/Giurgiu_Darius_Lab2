
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nume_Pren_Lab2.Models;

namespace WebApplication1.Pages.BookPages;

public class CreateModel : PageModel
{
    private readonly WebApplication1Context _context;

    public CreateModel(WebApplication1Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public IActionResult OnGet()
    {
        LoadPublishers();
        LoadAuthors();
        return Page();
    }

    private void LoadPublishers()
    {
        ViewData["PublisherID"] = new SelectList(
            _context.Set<Publisher>(),
            "ID",
            "PublisherName",
            Book?.PublisherID
        );
    }

    private void LoadAuthors()
    {
        ViewData["AuthorsID"] = new SelectList(
            _context.Set<Authors>()
                .Select(a => new
                {
                    a.ID,
                    FullName = a.FirstName + " " + a.LastName
                }),
            "ID",
            "FullName",
            Book?.AuthorsID
        );
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Book.Publisher");
        ModelState.Remove("Book.Authors");

        if (!ModelState.IsValid)
        {
            LoadPublishers();
            LoadAuthors();
            return Page();
        }

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
