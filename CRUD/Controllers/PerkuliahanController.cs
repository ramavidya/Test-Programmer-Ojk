
using CRUD.Data;
using CRUD.Models;
using CRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class PerkuliahanController : Controller
    {
        private readonly MVCDemoDbContext mVCDemoDbContext;

        public PerkuliahanController(MVCDemoDbContext context)
        {
            this.mVCDemoDbContext = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var perkuliahan = await mVCDemoDbContext.Perkuliahan.ToListAsync();
            return View(perkuliahan);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPerkuliahanViewModel model)
        {
        
            var perkuliahan = new Perkuliahan
            {
                DosenId = model.SelectedDosenId,
                MahasiswaId = model.SelectedMahasiswaId,
                MataKuliahId = model.SelectedMataKuliahId,
                Nilai = model.Nilai
            };

            await mVCDemoDbContext.Perkuliahan.AddAsync(perkuliahan);
            await mVCDemoDbContext.SaveChangesAsync();
          
            model.DosenList = mVCDemoDbContext.Dosen.ToList();
            model.MahasiswaList = mVCDemoDbContext.Mahasiswa.ToList();
            model.MataKuliahList = mVCDemoDbContext.MataKuliah.ToList();
            return RedirectToAction("Index");

        }

       
    }
}
