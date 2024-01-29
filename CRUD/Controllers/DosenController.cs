using CRUD.Data;
using CRUD.Models;
using CRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class DosenController : Controller
    {
        private readonly MVCDemoDbContext mVCDemoDbContext;

        public DosenController(MVCDemoDbContext mVCDemoDbContext)
        {
            this.mVCDemoDbContext = mVCDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dosen = await mVCDemoDbContext.Dosen.ToListAsync();
            return View(dosen);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddDosenViewModel request)
        {
            var dosen = new Dosen()
            {
                Nip = request.Nip,
                Nama = request.Nama
                
            };
            await mVCDemoDbContext.Dosen.AddAsync(dosen);
            await mVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var dosen = await mVCDemoDbContext.Dosen.FirstOrDefaultAsync(x => x.Id == id);
            if (dosen != null)
            {
                var viewModel = new UpdateDosenViewModel()
                {
                    Id = dosen.Id,
                    Nip = dosen.Nip,
                    Nama = dosen.Nama
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateDosenViewModel model)
        {
            var dosen = await mVCDemoDbContext.Dosen.FindAsync(model.Id);

            if (dosen != null)
            {
                dosen.Id = model.Id;
                dosen.Nip = model.Nip;
                dosen.Nama = model.Nama;

                await mVCDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateDosenViewModel model) 
        { 
            var dosen = await mVCDemoDbContext.Dosen.FindAsync(model.Id);

            if (dosen != null)
            {
                mVCDemoDbContext.Dosen.Remove(dosen);
                await mVCDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


    }
}

