using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ahtapot.Models
{
    public class Ahtapot
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
