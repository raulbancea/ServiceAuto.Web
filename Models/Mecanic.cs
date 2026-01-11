using System.ComponentModel.DataAnnotations;

namespace ServiceAuto.Web.Models
{
    public class Mecanic
    {
        public int MecanicId { get; set; }

        [Required, StringLength(50)]
        public string Nume { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Prenume { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; } = string.Empty;

        // simplu pentru proiect: parola hash/placeholder (mai jos facem Identity)
        [Required, StringLength(200)]
        public string ParolaHash { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Rol { get; set; } = "Mecanic"; // "Manager" / "Mecanic"

        public ICollection<Interventie> Interventii { get; set; } = new List<Interventie>();
    }
}
