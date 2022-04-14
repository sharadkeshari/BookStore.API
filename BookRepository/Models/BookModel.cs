using System.ComponentModel.DataAnnotations;

namespace BookRepository.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The title is required. Please add that.")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
