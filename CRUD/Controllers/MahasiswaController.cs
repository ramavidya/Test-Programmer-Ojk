using CRUD.Data;
using CRUD.Models.Domain;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class MahasiswaController : Controller
    {
        private readonly MVCDemoDbContext mVCDemoDbContext;

        public MahasiswaController(MVCDemoDbContext mVCDemoDbContext)
        {
            this.mVCDemoDbContext = mVCDemoDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mahasiswa = await mVCDemoDbContext.Mahasiswa.ToListAsync();
            return View(mahasiswa);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMahasiswaViewModel request)
        {
            var mahasiswa = new Mahasiswa()
            {
                Nim = request.Nim,
                Nama = request.Nama,
                Birth = request.Birth,
                Alamat = request.Alamat,
                JenisKelamin = request.JenisKelamin


            };
            await mVCDemoDbContext.Mahasiswa.AddAsync(mahasiswa);
            await mVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var mahasiswa = await mVCDemoDbContext.Mahasiswa.FirstOrDefaultAsync(x => x.Id == id);
            if (mahasiswa != null)
            {
                var viewModel = new UpdateMahasiswaViewModel()
                {
                    Id = mahasiswa.Id,
                    Nim = mahasiswa.Nim,
                    Nama = mahasiswa.Nama,
                    Birth = mahasiswa.Birth,
                    Alamat = mahasiswa.Alamat,
                    JenisKelamin = mahasiswa.JenisKelamin
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateMahasiswaViewModel model)
        {
            var mahasiswa = await mVCDemoDbContext.Mahasiswa.FindAsync(model.Id);

            if (mahasiswa != null)
            {
                mahasiswa.Id = model.Id;
                mahasiswa.Nim = model.Nim;
                mahasiswa.Nama = model.Nama;
                mahasiswa.Birth = model.Birth;
                mahasiswa.Alamat = model.Alamat;
                mahasiswa.JenisKelamin = model.JenisKelamin;

                await mVCDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateMahasiswaViewModel model)
        {
            var mahasiswa = await mVCDemoDbContext.Mahasiswa.FindAsync(model.Id);

            if (mahasiswa != null)
            {
                mVCDemoDbContext.Mahasiswa.Remove(mahasiswa);
                await mVCDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }

}
