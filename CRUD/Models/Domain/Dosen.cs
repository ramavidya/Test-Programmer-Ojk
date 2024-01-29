using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.Domain
{
    public class Dosen
    {
        [Key]
        public Guid Id { get; set; }
        public string? Nip { get; set; }

        [Column("Nama_Dosen")]
        public string? Nama { get; set; }

        public List<Perkuliahan>? Perkuliahan { get; set; }
    }
}
