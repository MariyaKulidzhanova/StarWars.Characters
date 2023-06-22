using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;
using StarWars.Characters.Data;
using StarWars.Characters.Models;

namespace StarWars.Characters.Controllers
{
    public class CharactersController : Controller
    {
        private readonly StarWarsCharactersContext _context;

        public CharactersController(StarWarsCharactersContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            if (_context.Character == null)
            {
                return Problem("Entity set 'StarWarsCharactersContext.Character' is null.");
            }

            if (searchString != null)
            {
                pageNumber = 1;
            }

            var characters = from c in _context.Character
                         select c;
            var characterVMList = new List<CharacterVM>();

            if (!String.IsNullOrEmpty(searchString))
            {
                characters = characters.Where(s => s.Name!.Contains(searchString) || s.Planet!.Contains(searchString) || s.Description!.Contains(searchString));
            }


            foreach (var character in characters)
                characterVMList.Add(new CharacterVM(character));


            int pageSize = 3;
            return View(characterVMList.ToPagedList(pageNumber ?? 1, pageSize));
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(new CharacterVM(character));
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDate,Planet,Gender,Race,Height,HairColor,EyeColor,Description,Movies")] Character character)
        {
            if (ModelState.IsValid)
            {
                //
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(new CharacterVM(character));
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(new CharacterVM(character));
        }

        // POST: Characters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthDate,Planet,Gender,Race,Height,HairColor,EyeColor,Description,Movies")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(new CharacterVM(character));
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(new CharacterVM(character));
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Character == null)
            {
                return Problem("Entity set 'StarWarsCharactersContext.Character'  is null.");
            }
            var character = await _context.Character.FindAsync(id);
            if (character != null)
            {
                _context.Character.Remove(character);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
          return (_context.Character?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
