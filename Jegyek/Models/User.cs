using System.ComponentModel.DataAnnotations;

namespace Jegyek.Models
{
    public class User
    {
        [Key]
        public Guid Azon { get; set; }
        public int Jegy { get; set; }
        public string Leiras { get; set; }
        public DateTime ido { get; set; }
    }
}
