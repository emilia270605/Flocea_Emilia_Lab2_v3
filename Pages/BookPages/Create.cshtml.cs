using Flocea_Emilia_Lab2_v3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nume_Pren_Lab2.Models;

namespace Flocea_Emilia_Lab2_v3.Pages.BookPages;

public class CreateModel : BookCategoriesPageModel
{
    private readonly Flocea_Emilia_Lab2_v3Context _context;

    public CreateModel(Flocea_Emilia_Lab2_v3Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
        ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "LastName");

        var book = new Book();
        book.BookCategories = new List<BookCategory>();
        PopulateAssignedCategoryData(_context, book);

        return Page();
    }

    private void PopulateAssignedCategoryData(Flocea_Emilia_Lab2_v3Context context, Book book)
    {
        
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
    {
        if (!ModelState.IsValid)
        {
            PopulateAssignedCategoryData(_context, Book);
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "LastName");
            return Page();
        }

        if (selectedCategories != null)
        {
            Book.BookCategories = new List<BookCategory>();
            foreach (var cat in selectedCategories)
            {
                var catToAdd = new BookCategory
                {
                    CategoryID = int.Parse(cat)
                };
                Book.BookCategories.Add(catToAdd);
            }
        }

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}