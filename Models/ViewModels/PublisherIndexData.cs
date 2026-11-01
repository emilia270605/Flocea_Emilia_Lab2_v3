using Flocea_Emilia_Lab2_v3.Models;
namespace Flocea_Emilia_Lab2_v3.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
