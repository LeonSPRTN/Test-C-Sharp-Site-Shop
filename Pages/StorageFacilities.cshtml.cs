using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestCSharp.Models;

namespace TestCSharp.Pages
{
    public class StorageFacilitiesModel : PageModel
    {

        private readonly ApplicationContext context;

        public List<StorageRoom> StorageRoom { get; set; }

        public StorageFacilitiesModel(ApplicationContext bd)
        {
            context = bd;
        }


        public void OnGet()
        {
            StorageRoom = context.TStorageRoom.AsNoTracking().ToList();

        }

        public async Task<IActionResult> OnPostDeleteAsync(int idStorageRoom)
        {
            var findStorageRoom = await context.TStorageRoom.FindAsync(idStorageRoom);

            if (findStorageRoom != null)
            {
                context.TStorageRoom.Remove(findStorageRoom);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
