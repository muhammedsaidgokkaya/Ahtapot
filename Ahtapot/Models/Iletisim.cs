using System.ComponentModel.DataAnnotations;

namespace Ahtapot.Models
{
    public class Iletisim
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string Faks { get; set; }
        public string Saatler { get; set; }
    }
}
