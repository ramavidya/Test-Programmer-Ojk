﻿using CRUD.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class UpdatePerkuliahanViewModel
    {
        public Guid PerkuliahanId { get; set; }

        [Display(Name = "Dosen")]
        public Guid SelectedDosenId { get; set; }

        [Display(Name = "Mahasiswa")]
        public Guid SelectedMahasiswaId { get; set; }

        [Display(Name = "Mata Kuliah")]
        public Guid SelectedMataKuliahId { get; set; }

        [Display(Name = "Nilai")]
        public string Nilai { get; set; }

        public List<Dosen> DosenList { get; set; }
        public List<Mahasiswa> MahasiswaList { get; set; }
        public List<MataKuliah> MataKuliahList { get; set; }

    }
}
