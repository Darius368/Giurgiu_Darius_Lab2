
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nume_Pren_Lab2.Models;

namespace WebApplication1.Pages.BookPages;

public class EditModel : PageModel
{
    private readonly WebApplication1Context _context;

    public EditModel(WebApplication1Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    private void LoadPublishers()
    {
        ViewData["PublisherID"] = new SelectList(
            _context.Publisher,
            "ID",
            "PublisherName",
            Book.PublisherID
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
            Book.AuthorsID
        );
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Book
            .FirstOrDefaultAsync(b => b.ID == id);

        if (book == null)
        {
            return NotFound();
        }

        Book = book;

        LoadPublishers();
        LoadAuthors();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Eliminam validarile pentru campurile vechi
        // si proprietatile de navigare
        ModelState.Remove("Book.Publisher");
        ModelState.Remove("Book.Authors");
        ModelState.Remove("Book.Author");

        if (!ModelState.IsValid)
        {
            LoadPublishers();
            LoadAuthors();
            return Page();
        }

        // Cautam cartea existenta in baza de date
        var bookInDatabase = await _context.Book
            .FirstOrDefaultAsync(b => b.ID == Book.ID);

        if (bookInDatabase == null)
        {
            return NotFound();
        }

        // Actualizam datele cartii
        bookInDatabase.Title = Book.Title;
        bookInDatabase.Price = Book.Price;
        bookInDatabase.PublishingDate = Book.PublishingDate;
        bookInDatabase.PublisherID = Book.PublisherID;

        // Actualizam autorul selectat
        bookInDatabase.AuthorsID = Book.AuthorsID;

        // Salvam modificarile
        await _context.SaveChangesAsync();

        // Revenim la lista cartilor
        return RedirectToPage("./Index");
    }
}
