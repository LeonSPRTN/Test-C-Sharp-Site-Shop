using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestCSharp.Models
{
    public class StorageRoom
    {
        [Key]
        public int idStorageRoom { get; set; }
        public string storageRoom { get; set; }
        public string Address { get; set; }
    }
}
