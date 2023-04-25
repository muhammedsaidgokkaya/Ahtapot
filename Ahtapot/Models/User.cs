using System.ComponentModel.DataAnnotations;

namespace Ahtapot.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
    }
}
