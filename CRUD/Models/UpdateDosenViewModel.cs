using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class UpdateDosenViewModel
    {
       
        public Guid Id { get; set; }
        public string? Nip { get; set; }

        [Column("Nama_Dosen")]
        public string? Nama { get; set; }
    }
}
