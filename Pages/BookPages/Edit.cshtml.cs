using Flocea_Emilia_Lab2_v3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nume_Pren_Lab2.Models;

namespace Flocea_Emilia_Lab2_v3.Pages.BookPages;

public class EditModel : BookCategoriesPageModel
{
    private readonly Flocea_Emilia_Lab2_v3Context _context;

    public EditModel(Flocea_Emilia_Lab2_v3Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Book = await _context.Book
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

        if (Book == null)
        {
            return NotFound();
        }

        PopulateAssignedCategoryData(_context, Book);

        ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
        ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "LastName");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bookToUpdate = await _context.Book
            .Include(i => i.Publisher)
            .Include(i => i.Author)
            .Include(i => i.BookCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);

        if (bookToUpdate == null)
        {
            return NotFound();
        }

        if (await TryUpdateModelAsync<Book>(
            bookToUpdate,
            "Book",
            i => i.Title, i => i.Price, i => i.PublishingDate, i => i.PublisherID, i => i.AuthorID))
        {
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        UpdateBookCategories(_context, selectedCategories, bookToUpdate);
        PopulateAssignedCategoryData(_context, bookToUpdate);

        ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
        ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "LastName");

        return Page();
    }
}