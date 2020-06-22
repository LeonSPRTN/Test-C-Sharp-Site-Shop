using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestCSharp.Models;

namespace TestCSharp
{
    public class WorkingGoodsModel : PageModel
    {
        private readonly ApplicationContext context;

        public List<Goods> Goods { get; set; }

        public WorkingGoodsModel(ApplicationContext bd)
        {
            context = bd;
        }
        public void OnGet()
        {
            Goods = context.TGoods.AsNoTracking().ToList();

        }

        public async Task<IActionResult> OnPostDeleteAsync(int idGoods)
        {
            var findGoods = await context.TGoods.FindAsync(idGoods);

            if (findGoods != null)
            {
                context.TGoods.Remove(findGoods);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}