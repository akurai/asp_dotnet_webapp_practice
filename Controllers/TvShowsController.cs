using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp_dotnet_webapp_MVC.Data;
using asp_dotnet_webapp_MVC.Models;
using System.Linq;

namespace asp_dotnet_webapp_MVC.Controllers{
    public class TvShowsController : Controller {
        private readonly asp_dotnet_webapp_MVCContext _context;

        public TvShowsController(asp_dotnet_webapp_MVCContext context){
            _context = context;
        }
        public async Task<IActionResult> Index(){
            return View(await _context.TvShow.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id){
            if(id == null){
                return NotFound();
            }

            var tvShow = await _context.TvShow.FirstOrDefaultAsync(m => m.Id == id);
            if(tvShow == null){
                return NotFound();
            }

            return View(tvShow);
        }
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Rating,ImdbUrl,ImageUrl")] TvShow tvShow){
            if(ModelState.IsValid){
                _context.Add(tvShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tvShow);
        }
        public async Task<IActionResult> Edit(int? id){
            if(id == null){
                return NotFound();
            }
            var tvShow = await _context.TvShow.FindAsync(id);
            if(tvShow == null){
                return NotFound();
            }
            return View(tvShow);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Rating,ImdbUrl,ImageUrl")] TvShow tvShow){
            if(id != tvShow.Id){
                return NotFound();
            }

            if(ModelState.IsValid){
                try{
                    _context.Update(tvShow);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException){
                    if(!TvShowExists(tvShow.Id)){
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tvShow);
        }
        public async Task<IActionResult> Delete(int? id){
            if(id == null){
                return NotFound();
            }
            var tvShow = await _context.TvShow.FirstOrDefaultAsync(m => m.Id == id);
            if(tvShow == null){
                return NotFound();
            }
            return View(tvShow);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id){
            var tvShow = await _context.TvShow.FindAsync(id);
            _context.TvShow.Remove(tvShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool TvShowExists(int id){
            return _context.TvShow.Any(e => e.Id == id);
        }

    }
}