using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.Domain
{
    public class Perkuliahan
    {
        [Key]
        public Guid PerkuliahanId { get; set; }

        // Foreign key untuk Dosen
        [ForeignKey("Dosen")]
        public Guid DosenId { get; set; }
        public Dosen? Dosen { get; set; }

        // Foreign key untuk Mahasiswa
        [ForeignKey("Mahasiswa")]
        public Guid MahasiswaId { get; set; }
        public Mahasiswa? Mahasiswa { get; set; }

        // Foreign key untuk MataKuliah
        [ForeignKey("MataKuliah")]
        public Guid MataKuliahId { get; set; }
        public MataKuliah? MataKuliah { get; set; }

        public string Nilai { get; set; }
    }
}
