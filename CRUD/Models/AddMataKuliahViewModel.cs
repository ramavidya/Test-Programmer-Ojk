using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class AddMataKuliahViewModel
    {
        [Column("Kode_MK")]
        public string? KodeMK { get; set; }

        [Column("Nama_MK")]
        public string? NamaMK { get; set; }

        public int Sks { get; set; }

    }
}
