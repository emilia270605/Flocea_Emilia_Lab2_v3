using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Flocea_Emilia_Lab2_v3.Models;

public class BookCategoriesPageModel : PageModel
{
    public List<AssignedCategoryData> AssignedCategoryDataList { get; set; } = new List<AssignedCategoryData>();

    public void PopulateAssignedCategoryData(Flocea_Emilia_Lab2_v3Context context, Book book)
    {
        var allCategories = context.Category.ToList();
        var bookCategories = new HashSet<int>();

        if (book != null && book.BookCategories != null)
        {
            bookCategories = new HashSet<int>(book.BookCategories.Select(c => c.CategoryID));
        }

        AssignedCategoryDataList = new List<AssignedCategoryData>();
        foreach (Category cat in allCategories)
        {
            AssignedCategoryDataList.Add(new AssignedCategoryData
            {
                CategoryID = cat.ID,
                Name = cat.CategoryName,
                Assigned = bookCategories.Contains(cat.ID)
            });
        }
    }

    public void UpdateBookCategories(Flocea_Emilia_Lab2_v3Context context, string[] selectedCategories, Book bookToUpdate)
    {
        if (selectedCategories == null)
        {
            bookToUpdate.BookCategories = new List<BookCategory>();
            return;
        }

        var selectedCategoriesHS = new HashSet<string>(selectedCategories);

        // ⭐ Am schimbat c.Category.ID în c.CategoryID pentru a preveni erorile de tip NullReference ⭐
        var bookCategories = new HashSet<int>(
            bookToUpdate.BookCategories?.Select(c => c.CategoryID) ?? Enumerable.Empty<int>());

        foreach (Category cat in context.Category)
        {
            if (selectedCategoriesHS.Contains(cat.ID.ToString()))
            {
                if (!bookCategories.Contains(cat.ID))
                {
                    bookToUpdate.BookCategories.Add(
                        new BookCategory { BookID = bookToUpdate.ID, CategoryID = cat.ID });
                }
            }
            else
            {
                if (bookCategories.Contains(cat.ID))
                {
                    var courseToRemove = bookToUpdate.BookCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                    if (courseToRemove != null)
                    {
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}