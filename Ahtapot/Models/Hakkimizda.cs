using System.ComponentModel.DataAnnotations;

namespace Ahtapot.Models
{
    public class Hakkimizda
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
