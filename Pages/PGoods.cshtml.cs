using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TestCSharp.Models;
using System;
using Microsoft.EntityFrameworkCore.Internal;

namespace TestCSharp
{
    public class PGoodsModel : PageModel
    {
        private readonly ApplicationContext context;

        public List<Goods> Goods { get; set; }

        public PGoodsModel(ApplicationContext bd)
        {
            context = bd;
        }

        public void OnGet()
        {
            Goods = context.TGoods.AsNoTracking().ToList();
        }

        public async Task<IActionResult> OnPostAsync(string name)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (name != null)
            {
                SqlParameter param = new SqlParameter("@name", name);
                Goods = await context.TGoods.FromSqlRaw("SELECT * FROM FunctionFindGoods(@name)", param).ToListAsync();
            }
            else
            {
                return NotFound();
            }

            return Page();
        }
    }
}