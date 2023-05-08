using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Ahtapot.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Wiki> Wikis { get; set; }
    }
}
