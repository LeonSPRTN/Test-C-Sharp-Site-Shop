using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCSharp.Pages.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TestCSharp.Pages
{
    public class EditGoodsModel : PageModel
    {  
        private readonly ApplicationContext context;


        public List<Goods> GoodsGet { get; set; }

        public EditGoodsModel(ApplicationContext db)
        {
            context = db;
        }

        public void OnGet()
        {
            GoodsGet = context.TGoods.AsNoTracking().ToList();
        }



        [BindProperty]
        public Goods Goods { get; set; }

        public async Task<IActionResult> OnPostDeleteAsync(int idGoods)
        {
            var goods = await context.TGoods.FindAsync(idGoods);

            if (goods != null)
            {
                context.TGoods.Remove(goods);
                await context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetAsync(int? idGoods)
        {
            if (idGoods == null)
            {
                return NotFound();
            }

            Goods = await context.TGoods.FindAsync(idGoods);

            if(Goods == null)
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
            return RedirectToPage("/EditGoods");
        }
    }
}
