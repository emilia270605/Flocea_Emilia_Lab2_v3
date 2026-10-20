using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Flocea_Emilia_Lab2_v3.Models;

namespace Flocea_Emilia_Lab2_v3.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Flocea_Emilia_Lab2_v3Context _context;

    public IndexModel(Flocea_Emilia_Lab2_v3Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Book = await _context.Book
            .Include(b=>b.Publisher)
            .Include(b=>b.Author)
            .ToListAsync();
    }
}
