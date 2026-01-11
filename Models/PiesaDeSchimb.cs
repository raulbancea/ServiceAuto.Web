using System.ComponentModel.DataAnnotations;

namespace ServiceAuto.Web.Models
{
    public class PiesaDeSchimb
    {
        public int PiesaDeSchimbId { get; set; }

        [Required, StringLength(100)]
        public string Denumire { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string CodProdus { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Furnizor { get; set; } = string.Empty;

        [Range(0.01, 100000)]
        public decimal Pret { get; set; }

        [Range(0, 100000)]
        public int Stoc { get; set; }

        public ICollection<InterventiePiesa> InterventiiPiese { get; set; } = new List<InterventiePiesa>();
    }
}
