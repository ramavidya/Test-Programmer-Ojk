using CRUD.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class AddDosenViewModel
    {
        public string? Nip { get; set; }

        [Column("Nama_Dosen")]
        public string? Nama { get; set; }
    }
}
