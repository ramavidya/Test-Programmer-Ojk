using CRUD.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class UpdateMahasiswaViewModel
    {
        public Guid Id { get; set; }
        public string? Nim { get; set; }

        [Column("Nama_Mhs")]
        public string? Nama { get; set; }

        [Column("Tgl_Lhr")]
        public DateTime Birth { get; set; }

        public string? Alamat { get; set; }

        public JenisKelamin JenisKelamin { get; set; }
    }
}
