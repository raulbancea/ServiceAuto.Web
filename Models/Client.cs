using System.ComponentModel.DataAnnotations;

namespace ServiceAuto.Web.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nume { get; set; }

        [Phone]
        public string Telefon { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(200)]
        public string Adresa { get; set; }

        [Required]
        public string TipClient { get; set; } // Persoana Fizica / Juridica
    }
}
