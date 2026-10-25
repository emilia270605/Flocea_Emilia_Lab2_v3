using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flocea_Emilia_Lab2_v3.Models
{
    public class Book
    {
        private Publisher? publisher;

        public int ID { get; set; }
        [Display(Name = "Book Title")]
        public string Title { get; set; }
        public int? AuthorID { get; set; }
        public Author? Author { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get => publisher; set => publisher = value; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
