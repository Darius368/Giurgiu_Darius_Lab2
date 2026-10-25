using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nume_Pren_Lab2.Models;

namespace WebApplication1.Pages.BookPages
{
public class IndexModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
{
private readonly WebApplication1Context _context;
public IndexModel(WebApplication1Context context) 
                        { 
                            _context = context; 
                        } 
                 
                        public IList<Book> Book { get;set; } 
                        public BookData BookD { get; set; } 
                        public int BookID { get; set; } 
                        public int CategoryID { get; set; } 
                 
                 
                        public async Task OnGetAsync(int? id, int? categoryID) 
                        { 
                            BookD = new BookData(); 
                           
                //se va include Author  conform cu sarcina de la lab 2 
                 
                          BookD.Books = await _context.Book 
                                .Include(b => b.Publisher)
                                .Include(b => b.Authors) 
                                .Include(b =>b.BookCategories) 
                                .ThenInclude(b =>b.Category) 
                                .AsNoTracking() 
                                .OrderBy(b => b.Title) 
                         .ToListAsync(); 
          
                     if (id != null) 
                     { 
                         BookID = id.Value; 
                         Book book = BookD.Books 
                             .Where(i => i.ID == id.Value).Single(); 
                        BookD.Categories = book.BookCategories.Select(s => s.Category); 
                     } 
          
                 }
}
}
