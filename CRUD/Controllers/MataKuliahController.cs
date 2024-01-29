using CRUD.Data;
using CRUD.Models.Domain;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class MataKuliahController : Controller
    {
        private readonly MVCDemoDbContext mVCDemoDbContext;

        public MataKuliahController(MVCDemoDbContext mVCDemoDbContext)
        {
            this.mVCDemoDbContext = mVCDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mataKuliah = await mVCDemoDbContext.MataKuliah.ToListAsync();
            return View(mataKuliah);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMataKuliahViewModel request)
        {
            var matkul = new MataKuliah()
            {
                KodeMK= request.KodeMK,
                NamaMK = request.NamaMK,
                Sks = request.Sks,

            };
            await mVCDemoDbContext.MataKuliah.AddAsync(matkul);
            await mVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var mataKuliah = await mVCDemoDbContext.MataKuliah.FirstOrDefaultAsync(x => x.Id == id);
            if (mataKuliah != null)
            {
                var viewModel = new UpdateMataKuliahViewModel()
                {
                    Id = mataKuliah.Id,
                    KodeMK = mataKuliah.KodeMK,
                    NamaMK = mataKuliah.NamaMK,
                    Sks = mataKuliah.Sks,
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateMataKuliahViewModel model)
        {
            var mataKuliah = await mVCDemoDbContext.MataKuliah.FindAsync(model.Id);

            if (mataKuliah != null)
            {
                mataKuliah.Id = model.Id;
                mataKuliah.KodeMK = model.KodeMK;
                mataKuliah.NamaMK = model.NamaMK;
                mataKuliah.Sks = model.Sks;

                await mVCDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateMataKuliahViewModel model)
        {
            var mataKuliah = await mVCDemoDbContext.MataKuliah.FindAsync(model.Id);

            if (mataKuliah != null)
            {
                mVCDemoDbContext.MataKuliah.Remove(mataKuliah);
                await mVCDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
