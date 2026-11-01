using Flocea_Emilia_Lab2_v3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Flocea_Emilia_Lab2_v3.Models;

namespace Flocea_Emilia_Lab2_v3.Pages.PublisherPages;

public class IndexModel : PageModel
{
    private readonly Flocea_Emilia_Lab2_v3Context _context;

    public IndexModel(Flocea_Emilia_Lab2_v3Context context)
    {
        _context = context;
    }

    public IList<Publisher> Publisher { get; set; } = default!;
    public PublisherIndexData PublisherData { get; set; }
    public int PublisherID { get; set; }
    public int BookID { get; set; }

    public async Task OnGetAsync(int? id, int? bookId)
    {
        Publisher = await _context.Publisher.ToListAsync();
        PublisherData = new PublisherIndexData();
        PublisherData.Publishers = await _context.Publisher
            .Include(i => i.Books)
                .ThenInclude(c => c.Author)
            .OrderBy(i => i.PublisherName)
            .ToListAsync();
        if (id != null)
        {
            PublisherID = id.Value;
            Publisher publisher = PublisherData.Publishers
                .Where(i => i.ID == id.Value).Single();
            PublisherData.Books = publisher.Books;
        }

    }
}
