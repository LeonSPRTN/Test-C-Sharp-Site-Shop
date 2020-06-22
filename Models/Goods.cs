
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestCSharp.Models
{
    public class Goods
    {
        [Key]
        public int idGoods { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string characteristic { get; set; }
        public decimal sum { get; set; }
        public int idStorageRoom { get; set; } 
    }
}
