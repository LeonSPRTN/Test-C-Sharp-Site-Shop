using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestCSharp.Models;

namespace TestCSharp
{
    public class EditStorageRoomModel : PageModel
    {
        private readonly ApplicationContext context;

        [BindProperty]
        public StorageRoom StorageRoom { get; set; }

        public EditStorageRoomModel(ApplicationContext bd)
        {
            context = bd;
        }

        public async Task<IActionResult> OnGetAsync(int? idStorageFacilities)
        {
            if (idStorageFacilities == null)
            {
                return NotFound();
            }

            StorageRoom = await context.TStorageRoom.FindAsync(idStorageFacilities);

            if (StorageRoom == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Attach(StorageRoom).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!context.TStorageRoom.Any(g => g.idStorageRoom == StorageRoom.idStorageRoom))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("/StorageFacilities");
        }
    }
}