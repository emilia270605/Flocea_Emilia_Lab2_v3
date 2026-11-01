using Flocea_Emilia_Lab2_v3.Models;
namespace Flocea_Emilia_Lab2_v3.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; } = default!;
        public IEnumerable<Book> Books { get; set; } = default!;
    }
}
