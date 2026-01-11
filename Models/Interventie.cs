using System.ComponentModel.DataAnnotations;

namespace ServiceAuto.Web.Models
{
    public class Interventie
    {
        public int InterventieId { get; set; }

        [Required]
        public int MasinaId { get; set; }

        [Required]
        public int MecanicId { get; set; }

        [Required]
        public DateTime DataProgramare { get; set; } = DateTime.Now;

        [Required, StringLength(20)]
        public string Status { get; set; } = "InAsteptare"; // InAsteptare / InLucru / Finalizata

        [Required, StringLength(500)]
        public string DescriereProblema { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ObservatiiMecanic { get; set; }

        public Masina? Masina { get; set; }
        public Mecanic? Mecanic { get; set; }

        public ICollection<InterventiePiesa> InterventiiPiese { get; set; } = new List<InterventiePiesa>();
    }
}
