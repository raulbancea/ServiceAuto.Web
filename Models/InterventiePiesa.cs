using System.ComponentModel.DataAnnotations;

namespace ServiceAuto.Web.Models
{
    // tabel de legătură M:N
    public class InterventiePiesa
    {
        [Required]
        public int InterventieId { get; set; }

        [Required]
        public int PiesaDeSchimbId { get; set; }

        [Range(1, 1000)]
        public int Cantitate { get; set; }

        [Range(0.01, 100000)]
        public decimal PretUnitarLaDataAplicarii { get; set; }

        public Interventie? Interventie { get; set; }
        public PiesaDeSchimb? PiesaDeSchimb { get; set; }
    }
}
