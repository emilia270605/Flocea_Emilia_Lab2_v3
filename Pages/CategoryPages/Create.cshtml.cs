using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Flocea_Emilia_Lab2_v3.Models;

namespace Flocea_Emilia_Lab2_v3.Pages.CategoryPages;

public class CreateModel : PageModel
{
    private readonly Flocea_Emilia_Lab2_v3Context _context;

    public CreateModel(Flocea_Emilia_Lab2_v3Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Category Category { get; set; } = default!;
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Category.Add(Category); 
        
         await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

  }

