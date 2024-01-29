using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.Domain
{
    public class MataKuliah
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Kode_MK")]
        public string? KodeMK { get; set; }

        [Column("Nama_MK")]
        public string? NamaMK { get; set; }

        public int Sks { get; set; }

        public List<Perkuliahan>? Perkuliahan { get; set; }
    }
}
