using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ServiceAuto.Web.Models
{
    public class Masina
    {
        public int MasinaId { get; set; }

        [Required]
        [StringLength(15)]
        public string NumarInmatriculare { get; set; }

        [Required]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Range(1950, 2100)]
        public int AnFabricatie { get; set; }

        [Required]
        [StringLength(50)]
        public string SerieSasiu { get; set; }

        // FK
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        // Navigation property (NU se validează la POST)
        [ValidateNever]
        public Client? Client { get; set; }
    }
}
