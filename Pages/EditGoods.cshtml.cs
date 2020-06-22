using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestCSharp.Models;

namespace TestCSharp.Pages
{
    public class EditGoodsModel : PageModel
    {
        private readonly ApplicationContext context;

        [BindProperty]
        public Goods Goods { get; set; }

        public EditGoodsModel(ApplicationContext bd)
        {
            context = bd;
        }

        public async Task<IActionResult> OnGetAsync(int? idGoods)
        {
            if (idGoods == null)
            {
                return NotFound();
            }

            Goods = await context.TGoods.FindAsync(idGoods);

            if (Goods == null)
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

            context.Attach(Goods).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!context.TGoods.Any(g => g.idGoods == Goods.idGoods))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("/WorkingGoods");
        }
    }
}
