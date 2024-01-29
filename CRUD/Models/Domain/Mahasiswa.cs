using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.Domain
{
    public enum JenisKelamin
    {
        Pria,
        Wanita
    }
    public class Mahasiswa
    {
        [Key]
        public Guid Id { get; set; }
        public string? Nim { get; set; }

        [Column("Nama_Mhs")]
        public string? Nama { get; set; }

        [Column("Tgl_Lhr")]
        public DateTime Birth { get; set; }

        public string? Alamat { get; set; }

        public JenisKelamin JenisKelamin { get; set; }

        public List<Perkuliahan>? Perkuliahan { get; set; }
    }
}
